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
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Event> events = _context.Events.OrderByDescending(e=>e.Id).Take(9).ToList();
            return View(events);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Event eventt = await _context.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).FirstOrDefaultAsync(e => e.Id == id);
            if (eventt == null) return NotFound();
            
            return View(eventt);
        }
    }
}
