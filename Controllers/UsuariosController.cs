﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncuentraAtuMascota.Models;


namespace EncuentraAtuMascota.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly EncuentraAtuMascotaContext _context;

        public UsuariosController(EncuentraAtuMascotaContext context)
        {
            _context = context;
        }

        // Obtener Lista de Usuarios
        public async Task<IActionResult> Administrar()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // Muestra Información del usuario
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // Crear nuevo usuario
        public IActionResult Crear()
        {
            return View();
        }

        //Graba nuevo usuario
        [HttpPost]
        public async Task<IActionResult> Crear([Bind("Id,Nombres,Apellidos,Sexo,Email,Telefono,FechaNacimiento,Direccion,Usuario,Clave")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();

                TempData["usuarios"] = usuarios.Usuario;

                //return RedirectToAction(nameof(UsuarioConfirmacion));
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("UsuarioConfirmacion");
            }
            return View(usuarios);
        }

        // Confirmar creación de Nuevo usuario
        public IActionResult UsuarioConfirmacion()
        {
            //Usuarios usuario = TempData["usuarios"] as Usuarios;

            //if (usuario == null)
            //{
            //    return RedirectToAction("Crear");
            //}

            //// Llevar el objeto "contacto" hasta la vista
            //ViewData["usuarios"] = usuario;

            return View();

        }

        //Modifica información del usuario
        public async Task<IActionResult> Modificar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);
        }

        //Graba datos modificados del usuario
        [HttpPost]
        public async Task<IActionResult> Modificar(int id, [Bind("Id,Nombres,Apellidos,Sexo,Email,Telefono,FechaNacimiento,Direccion,Usuario,Clave")] Usuarios usuarios)
        {
            if (id != usuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.Id))
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
            return View(usuarios);
        }

        // Elimina usuarios
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        //Elimina usuario de la BD
        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Administrar));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
