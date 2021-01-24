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
    public class ZleceniesController : Controller
    {
        private readonly SerwisContext _context;

        public ZleceniesController(SerwisContext context)
        {
            _context = context;
        }

        // GET: Zlecenies
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Zlecenies.ToListAsync());
            var serwisContext2 = _context.Zlecenies.Include(m => m.Mechanik);
            var sc = serwisContext2.Include(s => s.Samochod);
            return View(await sc.ToListAsync());
        }

        // GET: Zlecenies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlecenie = await _context.Zlecenies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zlecenie == null)
            {
                return NotFound();
            }

            return View(zlecenie);
        }

        // GET: Zlecenies/Create
        public IActionResult Create()
        {
            ViewData["IdMechanika"] = new SelectList(_context.Mechaniks, "Id", "ImieNazwiskoM");
            ViewData["IdSamochodu"] = new SelectList(_context.Samochods, "Id", "NazwaSamochodu");
            return View();
        }

        // POST: Zlecenies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OpisUsterki,Aktywne,IdSamochodu,IdMechanika")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zlecenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zlecenie);
        }

        // GET: Zlecenies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["IdMechanika"] = new SelectList(_context.Mechaniks, "Id", "ImieNazwiskoM");
            ViewData["IdSamochodu"] = new SelectList(_context.Samochods, "Id", "NazwaSamochodu");
            if (id == null)
            {
                return NotFound();
            }

            var zlecenie = await _context.Zlecenies.FindAsync(id);
            if (zlecenie == null)
            {
                return NotFound();
            }
            return View(zlecenie);
        }

        // POST: Zlecenies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OpisUsterki,Aktywne,IdSamochodu,IdMechanika")] Zlecenie zlecenie)
        {
            if (id != zlecenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zlecenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZlecenieExists(zlecenie.Id))
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
            return View(zlecenie);
        }

        // GET: Zlecenies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlecenie = await _context.Zlecenies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zlecenie == null)
            {
                return NotFound();
            }

            return View(zlecenie);
        }

        // POST: Zlecenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zlecenie = await _context.Zlecenies.FindAsync(id);
            _context.Zlecenies.Remove(zlecenie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZlecenieExists(int id)
        {
            return _context.Zlecenies.Any(e => e.Id == id);
        }
    }
}
