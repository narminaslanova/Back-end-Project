using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Helpers;
using EduHome.DAL;
using System.Text.RegularExpressions;

namespace EduHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; //for signin and out actions
        private readonly RoleManager<IdentityRole> _roleManager; //create update roles
        //private readonly ILogger<AccountController> _logger;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager /*ILogger<AccountController> logger*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            //_logger = logger;

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

           

            AppUser newUser = new AppUser
            {
                Fullname = register.Fullname,
                UserName = register.Username,
                Email = register.Email
            };
            IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
            if (!identityResult.Succeeded)
            {

                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            string code = _userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
            string link = Url.Action("VerifyEmail", "Account", new { userName = newUser.UserName, code = code }, protocol: HttpContext.Request.Scheme);

            await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());
            string aTag = $"<a href='{link}'>Click here for confirm</a>";
            await Helper.SendMessageAsync("Email Confirmation", aTag, newUser.Email);
            
            return RedirectToAction("EmailVerification", "Account");
        }
        public IActionResult EmailVerification()
        {
           
            return View();
        }
        public async Task<IActionResult> VerifyEmail(string userName, string code)
        {
            if (userName == null || code == null) return NotFound();
            AppUser user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            IdentityResult identityResult = await _userManager.ConfirmEmailAsync(user, code);
            if (identityResult.Succeeded)
            {
                bool IsExist = _context.Subscribers.Any(e => e.Email == user.Email);
                if (IsExist)
                {
                    return Content("This email already is subscribed");
                }
                Subscribers subscribers = new Subscribers() { Email = user.Email };
                await _context.Subscribers.AddAsync(subscribers);
                await _context.SaveChangesAsync();
                await _signInManager.SignInAsync(user, true);
                return View();
            }
            return BadRequest();
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(login.Username);
           
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }
            
            if (user.IsDeleted)
            {
                ModelState.AddModelError("", "This account has been deactivated");
                return View();
            }
            //isPersistent true -when you close browser it remembers your login, when it's false it will logout you itself
            var signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Please try a few minutes later");
                return View();
            }


            if (!signInResult.Succeeded)
            {

                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }

            if ((await _userManager.GetRolesAsync(user))[0] == Roles.Admin.ToString())
            {
                return RedirectToAction("index", "dashboard", new { area = "admin" });
            }

            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

       
      
        [HttpPost]
        public async Task<IActionResult> SendNotification(string email)
        {
           if (email == null) return Content("Please,insert email");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                return Content("Please,insert email");
            }
            else
            {
               bool IsExist= _context.Subscribers.Any(e => e.Email == email);
                if (IsExist)
                {
                    return Content("This email already is subscribed");
                }
                Subscribers subscribers = new Subscribers() { Email = email };
                await _context.Subscribers.AddAsync(subscribers);
                await _context.SaveChangesAsync();
            }
            return Content("You are now a subscriber!");
        }
        //this part is for coder
        #region Create Roles
        //public async Task CreateRoles()
        //{
        //    foreach (var role in Enum.GetValues(typeof(Roles)))
        //    {

        //        if (!(await _roleManager.RoleExistsAsync(role.ToString())))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole
        //            {
        //                Name = role.ToString()
        //            });
        //        }
        //    }

        //}
        #endregion
    }
}
