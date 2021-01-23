using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerwisSamochodowy.Models;

namespace SerwisSamochodowy.Controllers
{
    public class MechaniksController : Controller
    {
        private readonly SerwisContext _context;

        public MechaniksController(SerwisContext context)
        {
            _context = context;
        }

        // GET: Mechaniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mechaniks.ToListAsync());
        }

        // GET: Mechaniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechaniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanik == null)
            {
                return NotFound();
            }

            return View(mechanik);
        }

        // GET: Mechaniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mechaniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko")] Mechanik mechanik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mechanik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mechanik);
        }

        // GET: Mechaniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechaniks.FindAsync(id);
            if (mechanik == null)
            {
                return NotFound();
            }
            return View(mechanik);
        }

        // POST: Mechaniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko")] Mechanik mechanik)
        {
            if (id != mechanik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mechanik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MechanikExists(mechanik.Id))
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
            return View(mechanik);
        }

        // GET: Mechaniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mechanik = await _context.Mechaniks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mechanik == null)
            {
                return NotFound();
            }

            return View(mechanik);
        }

        // POST: Mechaniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanik = await _context.Mechaniks.FindAsync(id);
            _context.Mechaniks.Remove(mechanik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MechanikExists(int id)
        {
            return _context.Mechaniks.Any(e => e.Id == id);
        }
    }
}
