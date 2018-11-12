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
    public class AdoptarController : Controller
    {
        private readonly EncuentraAtuMascotaContext _context;

        public AdoptarController(EncuentraAtuMascotaContext context)
        {
            _context = context;
        }

        // Obtener Lista de Solicitudes de Adopción
        public async Task<IActionResult> Administrar()
        {
            return View(await _context.Adoptar.ToListAsync());
        }

        // Muestra información Solicitudes de adopción (adoptantes)
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptar = await _context.Adoptar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptar == null)
            {
                return NotFound();
            }

            return View(adoptar);
        }

        // Crear nueva solicitud de Adopción
        public IActionResult Crear()
        {
            return View();
        }

        //Graba nueva solicitud de Adopción
        [HttpPost]
        public async Task<IActionResult> Crear([Bind("Id,NombreAdoptante,Telefono,Email,Direccion,Comentarios,FotoMascota")] Adoptar adoptar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Administrar));
            }
            return View(adoptar);
        }

        // Modifica información de solicitud de Adopción
        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptar = await _context.Adoptar.FindAsync(id);
            if (adoptar == null)
            {
                return NotFound();
            }
            return View(adoptar);
        }

        // Graba datos modificados de la solicitud de adopción
        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("Id,NombreAdoptante,Telefono,Email,Direccion,Comentarios,FotoMascota")] Adoptar adoptar)
        {
            if (id != adoptar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptarExists(adoptar.Id))
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
            return View(adoptar);
        }

        // Eliminar solcitudes de adopción
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var adoptar = await _context.Adoptar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptar == null)
            {
                return NotFound();
            }
            return View(adoptar);
        }

        // Eliminar solicitud de adopción de la BD
        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptar = await _context.Adoptar.FindAsync(id);
            _context.Adoptar.Remove(adoptar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Administrar));
        }

        // Busca el Id de la Mascota que debe usar
        private bool AdoptarExists(int id)
        {
            return _context.Adoptar.Any(e => e.Id == id);
        }
    }
}
