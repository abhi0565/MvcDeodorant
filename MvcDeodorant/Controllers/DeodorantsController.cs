using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDeodorant.Data;
using MvcDeodorant.Models;

namespace MvcDeodorant.Controllers
{
    public class DeodorantsController : Controller
    {
        private readonly MvcDeodorantContext _context;

        public DeodorantsController(MvcDeodorantContext context)
        {
            _context = context;
        }

        // GET: Deodorants
        // GET: Movies
        public async Task<IActionResult> Index(string DeodorantFragrance, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> FragranceQuery = from d in _context.Deodorant
                                            orderby d.Fragrance
                                            select d.Fragrance;

            var Deodorants = from d in _context.Deodorant
                         select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                Deodorants = Deodorants.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DeodorantFragrance))
            {
                Deodorants = Deodorants.Where(x => x.Fragrance == DeodorantFragrance);
            }

            var DeodorantFragranceVM = new DeodorantFragranceViewModel
            {
                Fragrances = new SelectList(await FragranceQuery.Distinct().ToListAsync()),
                Deodorants = await Deodorants.ToListAsync()
            };

            return View(DeodorantFragranceVM);
        }

        // GET: Deodorants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deodorants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpiredDate,Fragrance,Quantity,Type,Rating")] Deodorant deodorant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deodorant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deodorant);
        }

        // GET: Deodorants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deodorant = await _context.Deodorant.FindAsync(id);
            if (deodorant == null)
            {
                return NotFound();
            }
            return View(deodorant);
        }

        // POST: Deodorants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpiredDate,Fragrance,Quantity,Type,Rating")] Deodorant deodorant)
        {
            if (id != deodorant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deodorant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeodorantExists(deodorant.Id))
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
            return View(deodorant);
        }

        // GET: Deodorants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deodorant = await _context.Deodorant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deodorant == null)
            {
                return NotFound();
            }

            return View(deodorant);
        }

        // POST: Deodorants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deodorant = await _context.Deodorant.FindAsync(id);
            _context.Deodorant.Remove(deodorant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeodorantExists(int id)
        {
            return _context.Deodorant.Any(e => e.Id == id);
        }
    }
}
