using CitasMedicas.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        } 

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
    }
}
