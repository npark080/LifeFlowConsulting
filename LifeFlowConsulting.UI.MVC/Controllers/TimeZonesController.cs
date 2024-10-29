using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LifeFlowConsulting.DATA.EF.Models;

namespace LifeFlowConsulting.UI.MVC.Controllers
{
    public class TimeZonesController : Controller
    {
        private readonly LifeFlowContext _context;

        public TimeZonesController(LifeFlowContext context)
        {
            _context = context;
        }

        // GET: TimeZones
        public async Task<IActionResult> Index()
        {
              return _context.TimeZones != null ? 
                          View(await _context.TimeZones.ToListAsync()) :
                          Problem("Entity set 'LifeFlowContext.TimeZones'  is null.");
        }

        // GET: TimeZones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeZones == null)
            {
                return NotFound();
            }

            var timeZone = await _context.TimeZones
                .FirstOrDefaultAsync(m => m.TimeZoneId == id);
            if (timeZone == null)
            {
                return NotFound();
            }

            return View(timeZone);
        }

        // GET: TimeZones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeZones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeZoneId,TimeZoneName")] DATA.EF.Models.TimeZone timeZone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeZone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeZone);
        }

        // GET: TimeZones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeZones == null)
            {
                return NotFound();
            }

            var timeZone = await _context.TimeZones.FindAsync(id);
            if (timeZone == null)
            {
                return NotFound();
            }
            return View(timeZone);
        }

        // POST: TimeZones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeZoneId,TimeZoneName")] DATA.EF.Models.TimeZone timeZone)
        {
            if (id != timeZone.TimeZoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeZone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeZoneExists(timeZone.TimeZoneId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeZone);
        }

        // GET: TimeZones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeZones == null)
            {
                return NotFound();
            }

            var timeZone = await _context.TimeZones
                .FirstOrDefaultAsync(m => m.TimeZoneId == id);
            if (timeZone == null)
            {
                return NotFound();
            }

            return View(timeZone);
        }

        // POST: TimeZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeZones == null)
            {
                return Problem("Entity set 'LifeFlowContext.TimeZones'  is null.");
            }
            var timeZone = await _context.TimeZones.FindAsync(id);
            if (timeZone != null)
            {
                _context.TimeZones.Remove(timeZone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeZoneExists(int id)
        {
          return (_context.TimeZones?.Any(e => e.TimeZoneId == id)).GetValueOrDefault();
        }
    }
}
