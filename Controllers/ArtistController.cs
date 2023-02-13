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
    public class ArtistController : Controller
    {
        private readonly CdContext _context;

        public ArtistController(CdContext context)
        {
            _context = context;
        }

        // GET: Artist
        public async Task<IActionResult> Index()
        {
              return _context.Artist_1 != null ? 
                          View(await _context.Artist_1.ToListAsync()) :
                          Problem("Entity set 'CdContext.Artist_1'  is null.");
        }

        // GET: Artist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artist_1 == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist_1
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,ArtistName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artist_1 == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist_1.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,ArtistName")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.ArtistId))
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
            return View(artist);
        }

        // GET: Artist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artist_1 == null)
            {
                return NotFound();
            }

            var artist = await _context.Artist_1
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artist_1 == null)
            {
                return Problem("Entity set 'CdContext.Artist_1'  is null.");
            }
            var artist = await _context.Artist_1.FindAsync(id);
            if (artist != null)
            {
                _context.Artist_1.Remove(artist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistExists(int id)
        {
          return (_context.Artist_1?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
