using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EduHome.Helpers.Helper;

namespace EduHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; //for signin and out actions
        private readonly RoleManager<IdentityRole> _roleManager; //create update roles
        //private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager /*ILogger<AccountController> logger*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());
            await _signInManager.SignInAsync(newUser, true);
            return RedirectToAction("Index", "Home");
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
