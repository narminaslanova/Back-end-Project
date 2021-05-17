using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = _context.Teachers.Include(t => t.TeacherDetails).ThenInclude(t => t.Skills).Include(t => t.SocialMedias).ToList();
            return View(teachers);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("Teacher,TeacherDetails,Skills,SocialMedias")] TeacherVM teacherVM)
        {
            if (teacherVM.Teacher == null || teacherVM.TeacherDetails == null || teacherVM.Skills == null || teacherVM.SocialMedias == null);
            Teacher teacher = teacherVM.Teacher;
            TeacherDetails teacherDetails = teacherVM.TeacherDetails;
            Skills skills = teacherVM.Skills;
            


            return RedirectToAction(nameof(Index));

        }
        
        
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _context.Teachers.Include(t => t.TeacherDetails).ThenInclude(t => t.Skills).FirstOrDefault(t => t.Id == id);
            return View(teacher);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = _context.Teachers.Include(t => t.TeacherDetails).ThenInclude(t => t.Skills).Include(t => t.SocialMedias).FirstOrDefault(t=>t.Id==id);
            if (teacher.IsDeleted == false)
            {
                teacher.IsDeleted = true;
            }
            else
            {
                teacher.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
