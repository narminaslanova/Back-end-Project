using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class CoursesViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public CoursesViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Courses> courses = _context.Courses.Take(take).ToList();
            return View(await Task.FromResult(courses));
        }
    }
}
