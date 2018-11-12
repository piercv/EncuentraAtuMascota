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
    public class MiMascotaController : Controller
    {
        private readonly EncuentraAtuMascotaContext _context;

        public MiMascotaController(EncuentraAtuMascotaContext context)
        {
            _context = context;
        }

        //Obtener Mis Mascotas - Lista
        public async Task<IActionResult> Administrar()
        {
            return View(await _context.MiMascota.ToListAsync());
        }

        //Muestra información de la Mascota
        public async Task<IActionResult> Detalle(int? id)
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

        //Creara nueva Mascota
        public IActionResult Crear()
        {
            return View();
        }

        //Graba información de nueva mascota en la BD
        [HttpPost]

        public async Task<IActionResult> Crear([Bind("Id,Nombre,Edad,Tamaño,Sexo,Raza,Descripcion,NombreDueno,Telefono,FotoMascota")] MiMascota miMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Administrar));
            }
            return View(miMascota);
        }

        //Modificar información de la Mascota
        public async Task<IActionResult> Modificar(int? id)
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

        //Graba datos modificados de la Mascota
        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("Id,Nombre,Edad,Tamaño,Sexo,Raza,Descripcion,NombreDueno,Telefono,FotoMascota")] MiMascota miMascota)
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
                return RedirectToAction(nameof(Administrar));
            }
            return View(miMascota);
        }

        // Eliminar Mascotas
        public async Task<IActionResult> Eliminar(int? id)
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

        ///Elimina Mascota de la BD
        [HttpPost, ActionName("Eliminar")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miMascota = await _context.MiMascota.FindAsync(id);
            _context.MiMascota.Remove(miMascota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Administrar));
        }

        private bool MiMascotaExists(int id)
        {
            return _context.MiMascota.Any(e => e.Id == id);
        }
    }
}
