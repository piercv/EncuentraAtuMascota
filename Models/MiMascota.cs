﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;


namespace EncuentraAtuMascota.Models
{
    public class MiMascota
    {
        public int Id { get; set; }

        [StringLength(100), Required]
        public string Nombre { get; set; }

        [Range(1,20), Required]
        public int Edad { get; set; }

        [StringLength(50), Required]
        public string Tamaño { get; set; }

        [StringLength(20), Required]
        public string Sexo { get; set; }

        [StringLength(50), Required]
        public string Raza { get; set; }

        [StringLength(100), Required]
        public string Descripcion { get; set; }

        [StringLength(100), Required]
        public string NombreDueno { get; set; }

        [Phone, StringLength(30), Required]
        public string Telefono { get; set; }

        //[Required]
        //public byte[] FotoMascota { get; set; }

        [StringLength(500), Required]
        public string FotoMascota { get; set; }

    }
}
