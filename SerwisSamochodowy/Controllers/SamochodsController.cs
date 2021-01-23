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
    public class SamochodsController : Controller
    {
        private readonly SerwisContext _context;

        public SamochodsController(SerwisContext context)
        {
            _context = context;
        }

        // GET: Samochods
        public async Task<IActionResult> Index()
        {
            var serwisContext = _context.Samochods.Include(s => s.Klient);
            return View(await serwisContext.ToListAsync());
        }

        // GET: Samochods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochods
                .Include(s => s.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // GET: Samochods/Create
        public IActionResult Create()
        {
            ViewData["KlientId"] = new SelectList(_context.Klients, "Id", "ImieNazwiskoK");
            return View();
        }

        // POST: Samochods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,Rejestracja,Vin,KlientId")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientId"] = new SelectList(_context.Klients, "Id", "Id", samochod.KlientId);
            return View(samochod);
        }

        // GET: Samochods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochods.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            ViewData["KlientId"] = new SelectList(_context.Klients, "Id", "ImieNazwiskoK", samochod.KlientId);
            return View(samochod);
        }

        // POST: Samochods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,Rejestracja,Vin,KlientId")] Samochod samochod)
        {
            if (id != samochod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.Id))
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
            ViewData["KlientId"] = new SelectList(_context.Klients, "Id", "Id", samochod.KlientId);
            return View(samochod);
        }

        // GET: Samochods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochods
                .Include(s => s.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samochod = await _context.Samochods.FindAsync(id);
            _context.Samochods.Remove(samochod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
            return _context.Samochods.Any(e => e.Id == id);
        }
    }
}
