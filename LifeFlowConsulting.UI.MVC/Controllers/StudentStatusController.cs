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
    public class StudentStatusController : Controller
    {
        private readonly LifeFlowContext _context;

        public StudentStatusController(LifeFlowContext context)
        {
            _context = context;
        }

        // GET: StudentStatus
        public async Task<IActionResult> Index()
        {
              return _context.StudentStatuses != null ? 
                          View(await _context.StudentStatuses.ToListAsync()) :
                          Problem("Entity set 'LifeFlowContext.StudentStatuses'  is null.");
        }

        // GET: StudentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentStatuses == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses
                .FirstOrDefaultAsync(m => m.StudentStatusId == id);
            if (studentStatus == null)
            {
                return NotFound();
            }

            return View(studentStatus);
        }

        // GET: StudentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentStatusId,StudentStatusName,StudentStatusDescription")] StudentStatus studentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentStatus);
        }

        // GET: StudentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentStatuses == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses.FindAsync(id);
            if (studentStatus == null)
            {
                return NotFound();
            }
            return View(studentStatus);
        }

        // POST: StudentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentStatusId,StudentStatusName,StudentStatusDescription")] StudentStatus studentStatus)
        {
            if (id != studentStatus.StudentStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentStatusExists(studentStatus.StudentStatusId))
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
            return View(studentStatus);
        }

        // GET: StudentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentStatuses == null)
            {
                return NotFound();
            }

            var studentStatus = await _context.StudentStatuses
                .FirstOrDefaultAsync(m => m.StudentStatusId == id);
            if (studentStatus == null)
            {
                return NotFound();
            }

            return View(studentStatus);
        }

        // POST: StudentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentStatuses == null)
            {
                return Problem("Entity set 'LifeFlowContext.StudentStatuses'  is null.");
            }
            var studentStatus = await _context.StudentStatuses.FindAsync(id);
            if (studentStatus != null)
            {
                _context.StudentStatuses.Remove(studentStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentStatusExists(int id)
        {
          return (_context.StudentStatuses?.Any(e => e.StudentStatusId == id)).GetValueOrDefault();
        }
    }
}
