using EduHome.DAL;
using EduHome.Extensions;
using EduHome.Models;
using EduHome.ViewModels;
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

        public IActionResult Create()
        {
            ViewBag.Speakers = _contex.Speakers.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Event,EventDetails,Speaker")]  EventVM eventVM)
        {
            if (eventVM.Event == null || eventVM.EventDetails == null || eventVM.Speaker == null) return NotFound();
            if (!ModelState.IsValid) return NotFound();
            ViewBag.Speakers = _contex.Speakers.ToList();
            
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

           await _contex.Events.AddAsync(eventVM.Event);
           await _contex.EventDetails.AddAsync(eventVM.EventDetails);
            await _contex.SpeakerEvent.AddRangeAsync(speakerEvents);
           await _contex.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Event eventt =  _contex.Events.Include(e => e.EventDetails).Include(e => e.SpeakerEvents).ThenInclude(e => e.Speaker).FirstOrDefault(e=>e.Id==id);
            if (eventt == null) return NotFound();
            ViewBag.Speakers = _contex.Speakers.ToList();
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
            ViewBag.Speakers = _contex.Speakers.ToList();
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
            _contex.Update(eventVM.Event);
            _contex.Update(eventVM.EventDetails);
            _contex.UpdateRange(speakerEvents);
            await _contex.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
