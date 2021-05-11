using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext _context;
        public TeachersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Teacher teacher = await _context.Teachers.Include(t=>t.SocialMedias).Include(t => t.TeacherDetails).ThenInclude(t => t.Skills).FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }
    }
}
