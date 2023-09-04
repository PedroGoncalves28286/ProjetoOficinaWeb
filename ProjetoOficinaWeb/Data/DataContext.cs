using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    
    public class DataContext : IdentityDbContext<User>
    { 
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailsTemp { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {



        }
    }
}
