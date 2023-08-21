using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }
    }
}
