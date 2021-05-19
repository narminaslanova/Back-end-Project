using EduHome.DAL;
using EduHome.Extensions;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Authorize(Roles = "Admin")]
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
            ViewBag.SocialMedia = _context.SocialMediaTable.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateAsync([Bind("Teacher,TeacherDetails,Skills,SocialMedias")] TeacherVM teacherVM)
        {
            
            if (teacherVM.Teacher == null || teacherVM.TeacherDetails == null || teacherVM.Skills == null || teacherVM.SocialMedia == null) return NotFound();
            Teacher teacher = teacherVM.Teacher;
            TeacherDetails teacherDetails = teacherVM.TeacherDetails;
            Skills skills = teacherVM.Skills;

            teacher.TeacherDetails = teacherDetails;
            teacherDetails.Skills = skills;
            teacherDetails.TeacherId = teacher.Id;
            skills.TeacherDetailsId = teacherDetails.Id;
            skills.TeacherDetails = teacherDetails;

            if (!teacher.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!teacher.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "teacher");
            teacher.ImageURL = await teacher.Photo.SaveFileAsync(_env.WebRootPath, filepath);

            List<SocialMedia> socialmedias = new List<SocialMedia>();
            List<SocialMediaTable> socials = _context.SocialMediaTable.ToList();
            foreach (var item in teacherVM.SocialMedia)
            {
                SocialMediaTable social = socials.FirstOrDefault(n => n.Id == item);
                socials.Add(new SocialMediaTable
                {
                    Icon = social.Icon,

                });
            }
            teacherVM.Teacher.SocialMedias = socialmedias;
            _context.Teachers.Add(teacher);
            _context.TeacherDetails.Add(teacherDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher=_context.Teachers.Include(t => t.TeacherDetails).ThenInclude(t => t.Skills).Include(t => t.SocialMedias).FirstOrDefault(t=>t.Id==id);
            if (teacher == null) return NotFound();
            ViewBag.SocialMedia = _context.SocialMediaTable.ToList();
            TeacherVM teacherVM = new TeacherVM
            {
                Teacher = teacher,
                TeacherDetails = teacher.TeacherDetails,
                Skills = teacher.TeacherDetails.Skills
            };
            return View(teacherVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Teacher,TeacherDetails,Skills,SocialMedias")] TeacherVM teacherVM)
        {
            if (teacherVM.Teacher == null || teacherVM.TeacherDetails == null || teacherVM.Skills == null) return NotFound();
            ViewBag.SocialMedia = _context.SocialMediaTable.ToList();
            if (!teacherVM.Teacher.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!teacherVM.Teacher.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "teacher");
            teacherVM.Teacher.ImageURL = await teacherVM.Teacher.Photo.SaveFileAsync(_env.WebRootPath, filepath);
            //teacherVM.Teacher.Id = id;
            //teacherVM.TeacherDetails.TeacherId = id;
            
            _context.Update(teacherVM.Teacher);
            _context.Update(teacherVM.TeacherDetails);
            _context.Update(teacherVM.Skills);
            await _context.SaveChangesAsync();
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
