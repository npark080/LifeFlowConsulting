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
    public class CourseStatusController : Controller
    {
        private readonly LifeFlowContext _context;

        public CourseStatusController(LifeFlowContext context)
        {
            _context = context;
        }

        // GET: CourseStatus
        public async Task<IActionResult> Index()
        {
              return _context.CourseStatuses != null ? 
                          View(await _context.CourseStatuses.ToListAsync()) :
                          Problem("Entity set 'LifeFlowContext.CourseStatuses'  is null.");
        }

        // GET: CourseStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseStatuses == null)
            {
                return NotFound();
            }

            var courseStatus = await _context.CourseStatuses
                .FirstOrDefaultAsync(m => m.CourseStatusId == id);
            if (courseStatus == null)
            {
                return NotFound();
            }

            return View(courseStatus);
        }

        // GET: CourseStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseStatusId,CourseStatusName")] CourseStatus courseStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseStatus);
        }

        // GET: CourseStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseStatuses == null)
            {
                return NotFound();
            }

            var courseStatus = await _context.CourseStatuses.FindAsync(id);
            if (courseStatus == null)
            {
                return NotFound();
            }
            return View(courseStatus);
        }

        // POST: CourseStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseStatusId,CourseStatusName")] CourseStatus courseStatus)
        {
            if (id != courseStatus.CourseStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseStatusExists(courseStatus.CourseStatusId))
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
            return View(courseStatus);
        }

        // GET: CourseStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseStatuses == null)
            {
                return NotFound();
            }

            var courseStatus = await _context.CourseStatuses
                .FirstOrDefaultAsync(m => m.CourseStatusId == id);
            if (courseStatus == null)
            {
                return NotFound();
            }

            return View(courseStatus);
        }

        // POST: CourseStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseStatuses == null)
            {
                return Problem("Entity set 'LifeFlowContext.CourseStatuses'  is null.");
            }
            var courseStatus = await _context.CourseStatuses.FindAsync(id);
            if (courseStatus != null)
            {
                _context.CourseStatuses.Remove(courseStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseStatusExists(int id)
        {
          return (_context.CourseStatuses?.Any(e => e.CourseStatusId == id)).GetValueOrDefault();
        }
    }
}
