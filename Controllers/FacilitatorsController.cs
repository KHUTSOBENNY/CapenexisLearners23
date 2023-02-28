using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners23.Data;
using CapenexisLearners23.Models;

namespace CapenexisLearners23.Controllers
{
    public class FacilitatorsController : Controller
    {
        private readonly CapenexisLearners23Context _context;

        public FacilitatorsController(CapenexisLearners23Context context)
        {
            _context = context;
        }

        // GET: Facilitators
        public async Task<IActionResult> Index()
        {
              return _context.Facilitator != null ? 
                          View(await _context.Facilitator.ToListAsync()) :
                          Problem("Entity set 'CapenexisLearners23Context.Facilitator'  is null.");
        }

        // GET: Facilitators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // GET: Facilitators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facilitators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,Surname,FacilitatorIdNumber,Course")] Facilitator facilitator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilitator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilitator);
        }

        // GET: Facilitators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator.FindAsync(id);
            if (facilitator == null)
            {
                return NotFound();
            }
            return View(facilitator);
        }

        // POST: Facilitators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,Surname,FacilitatorIdNumber,Course")] Facilitator facilitator)
        {
            if (id != facilitator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilitator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitatorExists(facilitator.Id))
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
            return View(facilitator);
        }

        // GET: Facilitators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facilitator == null)
            {
                return NotFound();
            }

            var facilitator = await _context.Facilitator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facilitator == null)
            {
                return NotFound();
            }

            return View(facilitator);
        }

        // POST: Facilitators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facilitator == null)
            {
                return Problem("Entity set 'CapenexisLearners23Context.Facilitator'  is null.");
            }
            var facilitator = await _context.Facilitator.FindAsync(id);
            if (facilitator != null)
            {
                _context.Facilitator.Remove(facilitator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitatorExists(int id)
        {
          return (_context.Facilitator?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
