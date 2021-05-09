﻿using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
                Courses=_context.Courses.Take(3).ToList(),
                NoticeBoards=_context.NoticeBoards.OrderByDescending(n=>n.Date).ToList(),
                InfoCards= _context.InfoCards.Take(3).ToList(),
                AboutInfo=_context.AboutInfos.FirstOrDefault(),
                Events=_context.Events.Take(4).ToList(),
                Testimonials=_context.Testimonials.ToList()
            };
            return View(homeVM);
        }
    }
}
