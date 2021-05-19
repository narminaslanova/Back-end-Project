using EduHome.DAL;
using EduHome.Extensions;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesforModeratorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        public CoursesforModeratorsController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();
            List<Courses> courses = _context.Courses.Where(c=>c.AppUserId==user.Id).Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).ToList();
            return View(courses);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Courses course = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return View();
            Courses course = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            CoursesVM coursesVM = new CoursesVM
            {
                Course = course,
                CoursesDetails = course.CoursesDetails,
                CourseFeatures = course.CoursesDetails.CourseFeatures
            };
           
            return View(coursesVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id,  [Bind("Course,CoursesDetails,CourseFeatures")] CoursesVM coursesVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (id == null) return NotFound();
            //Courses oldCourse = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (coursesVM.Course == null || coursesVM.CoursesDetails == null || coursesVM.CourseFeatures == null) return NotFound();
            if (!ModelState.IsValid) return NotFound();
            if (!coursesVM.Course.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!coursesVM.Course.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "course");
            coursesVM.Course.ImageURL = await coursesVM.Course.Photo.SaveFileAsync(_env.WebRootPath, filepath);
            coursesVM.Course.AppUserId = user.Id;
            
            _context.UpdateRange(coursesVM.Course, coursesVM.CoursesDetails, coursesVM.CourseFeatures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
