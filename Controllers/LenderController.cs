using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CdDirectory.Data;
using CdDirectory.Models;

namespace CdDirectory.Controllers
{
    public class LenderController : Controller
    {
        private readonly CdContext _context;

        public LenderController(CdContext context)
        {
            _context = context;
        }

        // GET: Lender
        public async Task<IActionResult> Index()
        {
              return _context.Lender != null ? 
                          View(await _context.Lender.ToListAsync()) :
                          Problem("Entity set 'CdContext.Lender'  is null.");
        }

        // GET: Lender/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lender == null)
            {
                return NotFound();
            }

            var lender = await _context.Lender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lender == null)
            {
                return NotFound();
            }

            return View(lender);
        }

        // GET: Lender/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lender/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LenderId,LenderName,StartLend,EndLend,Id")] Lender lender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lender);
        }

        // GET: Lender/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lender == null)
            {
                return NotFound();
            }

            var lender = await _context.Lender.FindAsync(id);
            if (lender == null)
            {
                return NotFound();
            }
            return View(lender);
        }

        // POST: Lender/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LenderId,LenderName,StartLend,EndLend,Id")] Lender lender)
        {
            if (id != lender.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LenderExists(lender.Id))
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
            return View(lender);
        }

        // GET: Lender/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lender == null)
            {
                return NotFound();
            }

            var lender = await _context.Lender
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lender == null)
            {
                return NotFound();
            }

            return View(lender);
        }

        // POST: Lender/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lender == null)
            {
                return Problem("Entity set 'CdContext.Lender'  is null.");
            }
            var lender = await _context.Lender.FindAsync(id);
            if (lender != null)
            {
                _context.Lender.Remove(lender);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LenderExists(int id)
        {
          return (_context.Lender?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
