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

       

        public DbSet<Client> Clients { get; set; }  

        public DbSet<Receptionist>Receptionists { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    var cascadeFKs = modelbuilder.Model
        //        .GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        //    foreach(var fk in cascadeFKs) 
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;          
        //    }
        //    base.OnModelCreating(modelbuilder);
        //}
    }
}
