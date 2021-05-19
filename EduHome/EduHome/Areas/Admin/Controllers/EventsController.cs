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
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public EventsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Event> eventt = await _context.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).ToListAsync();
            return View(eventt);
        }

        public IActionResult Create()
        {
            ViewBag.Speakers = _context.Speakers.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Event,EventDetails,Speaker")]  EventVM eventVM)
        {
            if (eventVM.Event == null || eventVM.EventDetails == null || eventVM.Speaker == null) return NotFound();
            if (!ModelState.IsValid) return NotFound();
            ViewBag.Speakers = _context.Speakers.ToList();
            
            if (!eventVM.Event.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!eventVM.Event.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }
            string filepath = Path.Combine("img", "event");
            eventVM.Event.ImageURL = await eventVM.Event.Photo.SaveFileAsync(_env.WebRootPath, filepath);

            List<SpeakerEvent> speakerEvents = new List<SpeakerEvent>();
            foreach (int item in eventVM.Speaker)
            {
                speakerEvents.Add(new SpeakerEvent
                {
                    EventId = eventVM.Event.Id,
                    SpeakerId = item

                });
            }
            eventVM.EventDetails.EventId = eventVM.Event.Id;
            eventVM.Event.SpeakerEvents = speakerEvents;
            eventVM.Event.EventDetails = eventVM.EventDetails;

           await _context.Events.AddAsync(eventVM.Event);
           await _context.EventDetails.AddAsync(eventVM.EventDetails);
            await _context.SpeakerEvent.AddRangeAsync(speakerEvents);
           await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Event eventt =  _context.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).FirstOrDefault(e=>e.Id==id);
            if (eventt == null) return NotFound();
            ViewBag.Speakers = _context.Speakers.ToList();
            List<int> speakers = new List<int>();
            foreach (SpeakerEvent item in eventt.SpeakerEvents)
            {
                speakers.Add(item.Id);
            }
            EventVM eventVM = new EventVM
            {
                Event = eventt,
                EventDetails = eventt.EventDetails,
                Speaker=speakers

            };
            return View(eventVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Event,EventDetails,Speaker")] EventVM eventVM)
        {
            if (eventVM.Event == null || eventVM.EventDetails == null || eventVM.Speaker == null) return NotFound();
            ViewBag.Speakers = _context.Speakers.ToList();
            if (!eventVM.Event.Photo.IsValidType("image/"))
            {
                ModelState.AddModelError("", "Please select image type");
                return View();
            }
            if (!eventVM.Event.Photo.IsValidSize(200))
            {
                ModelState.AddModelError("", "Image size should be less than 200kb");
                return View();
            }

            List<SpeakerEvent> speakerEvents = new List<SpeakerEvent>();
            foreach (int item in eventVM.Speaker)
            {

                speakerEvents.Add(new SpeakerEvent
                {
                    EventId = eventVM.Event.Id,
                    SpeakerId = item

                });
            }
            


            string filepath = Path.Combine("img", "event");
            eventVM.Event.ImageURL = await eventVM.Event.Photo.SaveFileAsync(_env.WebRootPath, filepath);
            _context.Update(eventVM.Event);
            _context.Update(eventVM.EventDetails);
            _context.UpdateRange(speakerEvents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            Event event1 = await _context.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).FirstOrDefaultAsync(e => e.Id == id);
            return View(event1);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            Event event1 =  _context.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).ToList().Find(e=>e.Id==id);
            
            if (event1 == null) return NotFound();
           
            if (event1.IsDeleted == false)
            {
               
                event1.IsDeleted = true;
            }
            else
            {
                event1.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
