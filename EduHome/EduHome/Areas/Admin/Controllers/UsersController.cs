using EduHome.DAL;
using EduHome.Helpers;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int? page)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_userManager.Users.Count() /5);
            ViewBag.Page = page;
            if (page == null)
            {
                List<AppUser> users = _userManager.Users.Take(5).OrderBy(x => x.Fullname).ToList();
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
            }
            List<AppUser> users1 = _userManager.Users.Skip(((int)page - 1) * 5).Take(5).OrderBy(x => x.Fullname).ToList();
            List<UserVM> userVMs1 = new List<UserVM>();
            foreach (AppUser user in users1)
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
                userVMs1.Add(userVM);
            }

            return View(userVMs1);
            // Skip(((int)page - 1) * 3).Take(3)
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

        public async Task<IActionResult> ChangeRole(string id)
        {

            AppUser user = await _userManager.FindByIdAsync(id);
            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Email = user.Email,
                Username = user.UserName,
                IsDeleted = user.IsDeleted,
                Role = (await _userManager.GetRolesAsync(user))[0]
            };
            TempData["oldRole"] = userVM.Role;
            ViewBag.coursesList = _context.Courses.Where(c=>c.AppUserId==null).ToList();
            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeRole(UserVM userVM, string newRole, List<int?> CourseId)
        {
            ViewBag.coursesList = _context.Courses.Where(c => c.AppUserId == null).ToList();
            if (userVM == null) return NotFound();
            if (newRole == null) return NotFound();
            AppUser userapp = await _userManager.FindByIdAsync(userVM.Id);
            if (userapp == null) return NotFound();

            
            string oldRole = (await _userManager.GetRolesAsync(userapp))[0];
            TempData["oldRole"] = oldRole;
            string currentUserName = User.Identity.Name;

            AppUser currentAppUser = await _userManager.FindByNameAsync(currentUserName);
            string currentRole = (await _userManager.GetRolesAsync(currentAppUser))[0];
            
                if (currentRole == Roles.Admin.ToString())
            {
                var addedToRole = await _userManager.AddToRoleAsync(userapp, newRole);
                if (addedToRole.Succeeded)
                {
                    
                    await _userManager.RemoveFromRoleAsync(userapp, oldRole);
                    await _userManager.UpdateAsync(userapp);
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View();
                }
            }
            else if (currentRole == Roles.Moderator.ToString())
            {

                if (newRole != Roles.Admin.ToString() && oldRole != Roles.Admin.ToString())
                {
                    var addedToRole = await _userManager.AddToRoleAsync(userapp, newRole);
                    
                    if (addedToRole.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(userapp, oldRole);
                        
                        await _userManager.UpdateAsync(userapp);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You cannot change this role");
                    return View();
                }

            }
            else if (currentRole == Roles.Member.ToString())
            {
                ModelState.AddModelError("", "You cannot change any roles");
                return View();
            }

            if (CourseId != null)
            {
                //Courses course = _context.Courses.FirstOrDefault(c => c.Id == CourseId);
                List<Courses> courses = new List<Courses>();
               
                foreach (int item in CourseId)
                {
                    Courses course = new Courses();

                    course =await _context.Courses.FirstOrDefaultAsync(c => c.Id == item);
                    courses.Add(course);
                    
                }

                foreach (Courses course in courses)
                {
                    course.AppUserId = userapp.Id;
                    _context.Courses.Update(course);
                }
               // userapp.Courses = courses;
               
                await _userManager.UpdateAsync(userapp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
