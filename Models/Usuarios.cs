using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;    //Agregado

namespace EncuentraAtuMascota.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Nombres { get; set; }

        [StringLength(100), Required]
        public string Apellidos { get; set; }

        public string Sexo { get; set; }

        [StringLength(100), EmailAddress, Required]
        public string Email { get; set; }

        [Phone, StringLength(30), Required]
        public string Telefono { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(100), Required]
        public string Direccion { get; set; }

        [StringLength(40), Required]
        public string Usuario { get; set; }

        [StringLength(40), Required]
        public string Clave { get; set; }
    }
}
