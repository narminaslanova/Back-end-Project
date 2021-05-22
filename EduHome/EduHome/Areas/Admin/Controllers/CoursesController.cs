using EduHome.DAL;
using EduHome.Extensions;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public CoursesController(AppDbContext context, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }
        public IActionResult Index(int? page)
        {
            
            ViewBag.PageCount = Decimal.Ceiling((decimal)_context.Courses.Where(c=>c.IsDeleted==false).Count() / 3);
            ViewBag.Page = page;
            if (page==null)
            {
                List<Courses> courses = _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).OrderByDescending(e => e.Id).Take(3).ToList();
                return View(courses);
            }
            return View(_context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).OrderByDescending(e => e.Id).Skip(((int)page-1)*3).Take(3).ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Courses course = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Course,CoursesDetails,CourseFeatures")] CoursesVM coursesVM)
        {
            if (coursesVM.Course == null || coursesVM.CoursesDetails == null || coursesVM.CourseFeatures == null) return NotFound();
            if (!ModelState.IsValid) return NotFound();
            Courses course = coursesVM.Course;
            CoursesDetails coursesDetails = coursesVM.CoursesDetails;
            CourseFeatures courseFeatures = coursesVM.CourseFeatures;

            course.CoursesDetails = coursesDetails;
            coursesDetails.Course = course;
            coursesDetails.CourseId = course.Id;
            coursesDetails.CourseFeatures = courseFeatures;
            courseFeatures.CoursesDetails = coursesDetails;
            courseFeatures.CourseDetailsId = coursesDetails.Id;

            //if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
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
           // return Json($"{course.Id},{coursesDetails.Id},{courseFeatures.Id}, {coursesDetails.CourseId}, {courseFeatures.CourseDetailsId}");

            await _context.Courses.AddAsync(course);
            await _context.CourseDetailes.AddAsync(coursesDetails);
            await _context.CourseFeatures.AddAsync(courseFeatures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Update(int? id)
        {
           

            if (id == null) return View();
            Courses course = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            CoursesVM coursesVM = new CoursesVM
            {
                Course = course,
                CoursesDetails=course.CoursesDetails,
                CourseFeatures=course.CoursesDetails.CourseFeatures
            };
            return View(coursesVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,[Bind("Course,CoursesDetails,CourseFeatures")] CoursesVM coursesVM)
        {
            //if (id == null) return NotFound();
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
            _context.UpdateRange(coursesVM.Course, coursesVM.CoursesDetails, coursesVM.CourseFeatures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Courses course =await _context.Courses.FindAsync(id);
            if (course.IsDeleted == false)
            {
                course.IsDeleted = true;
            }
            else
            {
                course.IsDeleted = false;
            }


            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
