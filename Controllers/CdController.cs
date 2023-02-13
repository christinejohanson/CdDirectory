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
    public class CdController : Controller
    {
        private readonly CdContext _context;

        public CdController(CdContext context)
        {
            _context = context;
        }

        /* GET: Cd Original cd/index.
        public async Task<IActionResult> Index()
        {
            var cdContext = _context.Cd.Include(c => c.Artist);
            return View(await cdContext.ToListAsync()); 
        } */

        /* index med sökfunktion */
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var cdContext = from s in _context.Cd.Include(s => s.Artist)
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cdContext = cdContext.Where(s => s.Name.Contains(searchString));

                /*   cdContext = cdContext.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));*/

            }
            return View(await cdContext.ToListAsync());

        }



        // GET: Cd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // GET: Cd/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist_1, "ArtistId", "ArtistName");
            return View();
        }

        // POST: Cd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Releaseyear,ArtistId")] Cd cd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist_1, "ArtistId", "ArtistName", cd.ArtistId);
            return View(cd);
        }

        // GET: Cd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist_1, "ArtistId", "ArtistName", cd.ArtistId);
            return View(cd);
        }

        // POST: Cd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Releaseyear,ArtistId")] Cd cd)
        {
            if (id != cd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CdExists(cd.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist_1, "ArtistId", "ArtistId", cd.ArtistId);
            return View(cd);
        }

        // GET: Cd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cd == null)
            {
                return NotFound();
            }

            var cd = await _context.Cd
                .Include(c => c.Artist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cd == null)
            {
                return NotFound();
            }

            return View(cd);
        }

        // POST: Cd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cd == null)
            {
                return Problem("Entity set 'CdContext.Cd'  is null.");
            }
            var cd = await _context.Cd.FindAsync(id);
            if (cd != null)
            {
                _context.Cd.Remove(cd);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CdExists(int id)
        {
            return (_context.Cd?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
