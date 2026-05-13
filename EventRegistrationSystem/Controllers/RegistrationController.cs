using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventRegistrationSystem.Data;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _context;

        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Registrations.Include(r => r.Event).Include(r => r.Participant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Registration/Create
        public IActionResult Create()
        {
            // Sadece bugün ve gelecek etkinlikleri getir
            var futureEvents = _context.Events.Where(e => e.EventDate >= DateTime.Today).ToList();
            ViewData["EventId"] = new SelectList(futureEvents, "Id", "EventName");
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FullName");
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventId,ParticipantId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                // Bonus: Kapasite Kontrolü
                var @event = await _context.Events
                    .Include(e => e.Registrations)
                    .FirstOrDefaultAsync(e => e.Id == registration.EventId);

                if (@event != null)
                {
                    if (@event.Registrations.Count >= @event.Capacity)
                    {
                        ModelState.AddModelError("", "Hata: Bu etkinlik tam kapasiteye ulaşmıştır.");
                        var futureEventsOnCap = _context.Events.Where(e => e.EventDate >= DateTime.Today).ToList();
                        ViewData["EventId"] = new SelectList(futureEventsOnCap, "Id", "EventName", registration.EventId);
                        ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FullName", registration.ParticipantId);
                        return View(registration);
                    }
                    
                    // Aynı kişinin aynı etkinliğe birden fazla kayıt olmasını engellemek de iyi bir pratiktir
                    var existingRegistration = await _context.Registrations
                        .FirstOrDefaultAsync(r => r.EventId == registration.EventId && r.ParticipantId == registration.ParticipantId);
                    
                    if (existingRegistration != null)
                    {
                        ModelState.AddModelError("", "Hata: Bu katılımcı zaten bu etkinliğe kayıtlı.");
                        var futureEventsOnExist = _context.Events.Where(e => e.EventDate >= DateTime.Today).ToList();
                        ViewData["EventId"] = new SelectList(futureEventsOnExist, "Id", "EventName", registration.EventId);
                        ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FullName", registration.ParticipantId);
                        return View(registration);
                    }
                }

                registration.RegistrationDate = DateTime.Now;
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var futureEventsOnError = _context.Events.Where(e => e.EventDate >= DateTime.Today).ToList();
            ViewData["EventId"] = new SelectList(futureEventsOnError, "Id", "EventName", registration.EventId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FullName", registration.ParticipantId);
            return View(registration);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var registration = await _context.Registrations
                .Include(r => r.Event)
                .Include(r => r.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (registration == null) return NotFound();

            return View(registration);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
