using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CoursesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Courses> courses =await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).ToListAsync();
            return View(courses);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Courses course = await _context.Courses.Include(c => c.CoursesDetails).ThenInclude(c => c.CourseFeatures).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return NotFound();
            return View(course);
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
