using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EncuentraAtuMascota.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Adoptar()
        {
            return View();
        }

        public IActionResult RegistroMiMascota()
        {
            return View();
        }
    }
}