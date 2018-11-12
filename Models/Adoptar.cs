using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;    //Agregado


namespace EncuentraAtuMascota.Models
{
    public class Adoptar
    {
        public int Id { get; set; }

        public int MiMascotaID { get; set; }

        [StringLength(100), Required]
        public string NombreAdoptante { get; set; }  

        [Phone, StringLength(30), Required]
        public string Telefono { get; set; }

        [StringLength(100), EmailAddress, Required]
        public string Email { get; set; }

        [StringLength(100), Required]
        public string Direccion { get; set; }

        [StringLength(200), Required]
        public string Comentarios { get; set; }

        public ICollection<MiMascota> MiMascota { get; set; }

    }
}
