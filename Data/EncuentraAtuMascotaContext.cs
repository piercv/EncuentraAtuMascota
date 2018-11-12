using Microsoft.EntityFrameworkCore;
using EncuentraAtuMascota.Models;

namespace EncuentraAtuMascota.Models
{
    public class EncuentraAtuMascotaContext : DbContext
    {
        public EncuentraAtuMascotaContext (DbContextOptions<EncuentraAtuMascotaContext> options)
            : base(options)
        {
        }

        public DbSet<EncuentraAtuMascota.Models.Usuarios> Usuarios { get; set; }

        public DbSet<EncuentraAtuMascota.Models.MiMascota> MiMascota { get; set; }

        public DbSet<EncuentraAtuMascota.Models.Adoptar> Adoptar { get; set; }

    }
}
