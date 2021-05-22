using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders=_context.Sliders.ToList(),
                InfoCards= _context.InfoCards.Take(3).ToList(),
                Events=_context.Events.Take(4).ToList()
                
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Search(string name,string page)
        {
            if (page == "Course")
            {
                List<Courses> courses = await _context.Courses.Where(c=>c.Name.ToLower().Contains(name)).ToListAsync();
                return PartialView("_CoursePartial" ,courses);
            }
            else if (page == "Blog")
            {
                List<Blog> blogs = await _context.Blogs.Where(c => c.Title.Contains(name)).ToListAsync();
                return PartialView("_BlogPartial", blogs);
            }
            else if (page == "Teacher")
            {
                List<Teacher> teachers = await _context.Teachers.Where(c => c.FullName.Contains(name)).ToListAsync();
                return PartialView("_TeacherPartial", teachers);
            }
            else if (page == "Event")
            {
                List<Event> eventt = await _context.Events.Where(c => c.Title.Contains(name)).ToListAsync();
                return PartialView("_EventPartial", eventt);
            }
            else{
                return Content("Error");
            }
            
        }

        public async Task<IActionResult> GlobalSearch(string search)
        {
            SearchVM searchVM = new SearchVM
            {
                Courses = await _context.Courses.Where(c => c.IsDeleted == false && c.Name.Contains(search)).Take(2).ToListAsync(),
                Teachers = await _context.Teachers.Where(c => c.IsDeleted == false && c.FullName.Contains(search)).Take(2).ToListAsync(),
                Blogs = await _context.Blogs.Where(c => c.IsDeleted == false && c.Title.Contains(search)).Take(2).ToListAsync(),
                Events = await _context.Events.Where(c => c.IsDeleted == false && c.Title.Contains(search)).Take(2).ToListAsync()
            };
            return PartialView("_GlobalPartial", searchVM);
        }
    }
}
