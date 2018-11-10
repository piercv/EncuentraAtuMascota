using Microsoft.EntityFrameworkCore;

namespace EncuentraAtuMascota.Models
{
    public class EncuentraAtuMascotaContext : DbContext
    {
        public EncuentraAtuMascotaContext (DbContextOptions<EncuentraAtuMascotaContext> options)
            : base(options)
        {
        }

        public DbSet<EncuentraAtuMascota.Models.Usuarios> Usuarios { get; set; }
    }
}
