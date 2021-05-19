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

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            List<AppUser> users = _userManager.Users.ToList();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    Id = user.Id,
                    Fullname = user.Fullname,
                    Email = user.Email,
                    Username = user.UserName,
                    IsDeleted = user.IsDeleted,
                    Role = (await _userManager.GetRolesAsync(user))[0]
                };
                userVMs.Add(userVM);
            }

            return View(userVMs);
            // return View();
        }

        public async Task<IActionResult> Activate(string id)
        {
            if (id == null) return NotFound();
            AppUser userapp = await _userManager.FindByIdAsync(id);
            if (userapp == null) return NotFound();

            string role = (await _userManager.GetRolesAsync(userapp))[0];
            
            //string userName = ;

           
            AppUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //return Json(currentUser);

            string currentRole = (await _userManager.GetRolesAsync(currentUser))[0];

            if (currentRole == null || role == null) return NotFound();

            if (currentRole == Roles.Admin.ToString())
            {
                if (userapp.IsDeleted)
                {
                    userapp.IsDeleted = false;
                }
                else
                {
                    userapp.IsDeleted = true;
                }
            }
            else
            {

                return Content("You cannot deactivate any user");


            }



            await _userManager.UpdateAsync(userapp);
            return RedirectToAction(nameof(Index));

        }
    }
}
