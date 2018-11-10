using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncuentraAtuMascota.Models;

namespace EncuentraAtuMascota.Controllers
{
    public class MiMascotasController : Controller
    {
        private readonly EncuentraAtuMascotaContext _context;

        public MiMascotasController(EncuentraAtuMascotaContext context)
        {
            _context = context;
        }

        // GET: MiMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.MiMascota.ToListAsync());
        }

        // GET: MiMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miMascota = await _context.MiMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miMascota == null)
            {
                return NotFound();
            }

            return View(miMascota);
        }

        // GET: MiMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MiMascotas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Tamaño,Sexo,Raza,Descripción,NombreDueno,Telefono,FotoMascota")] MiMascota miMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miMascota);
        }

        // GET: MiMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miMascota = await _context.MiMascota.FindAsync(id);
            if (miMascota == null)
            {
                return NotFound();
            }
            return View(miMascota);
        }

        // POST: MiMascotas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Tamaño,Sexo,Raza,Descripción,NombreDueno,Telefono,FotoMascota")] MiMascota miMascota)
        {
            if (id != miMascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiMascotaExists(miMascota.Id))
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
            return View(miMascota);
        }

        // GET: MiMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miMascota = await _context.MiMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miMascota == null)
            {
                return NotFound();
            }

            return View(miMascota);
        }

        // POST: MiMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miMascota = await _context.MiMascota.FindAsync(id);
            _context.MiMascota.Remove(miMascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiMascotaExists(int id)
        {
            return _context.MiMascota.Any(e => e.Id == id);
        }
    }
}
