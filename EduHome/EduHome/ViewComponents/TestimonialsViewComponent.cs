using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TestimonialsViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public TestimonialsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Testimonials> testimonials = _context.Testimonials.ToList();
            return View(await Task.FromResult(testimonials));
        }
    }
}
