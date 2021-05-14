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
    public class EventsController : Controller
    {
        private readonly AppDbContext _contex;
        private readonly IWebHostEnvironment _env;
        public EventsController(AppDbContext context, IWebHostEnvironment env)
        {
            _contex = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> eventt = await _contex.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).ToListAsync();
            return View(eventt);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Event event1 = await _contex.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).FirstOrDefaultAsync(e => e.Id == id);
            return View(event1);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Event event1 =  _contex.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).ToList().Find(e=>e.Id==id);
            
            if (event1 == null) return NotFound();
           
            if (event1.IsDeleted == false)
            {
               
                event1.IsDeleted = true;
            }
            else
            {
                event1.IsDeleted = false;
            }
            await _contex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
