using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class AboutInfoViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public AboutInfoViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AboutInfo AboutInfo = _context.AboutInfos.FirstOrDefault();

            return View(await Task.FromResult(AboutInfo));
        }
    }
}
