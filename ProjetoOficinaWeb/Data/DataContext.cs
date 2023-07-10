using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class DataContext : IdentityDbContext<User> 
    {

        public DbSet<Vehicle> Vehicles { get; set; } 

        public DbSet<Service> Services { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        public DbSet<AppointmentDetail> AppointmentDetails { get; set; }

        public DbSet<AppointmentDetailTemp> AppointmentDetailsTemp { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Country>()
        //        .HasIndex(c => c.Name)
        //        .IsUnique();


        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.Price)
        //        .HasColumnType("decimal(18,2)");


        //    modelBuilder.Entity<OrderDetailTemp>()
        //       .Property(p => p.Price)
        //       .HasColumnType("decimal(18,2)");


        //    modelBuilder.Entity<OrderDetail>()
        //      .Property(p => p.Price)
        //      .HasColumnType("decimal(18,2)");


        //    base.OnModelCreating(modelBuilder);
        //}

        //Habilitar a regra de apagar em cascata (Cascade Delete Rule)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var cascadeFKs = modelBuilder.Model
        //        .GetEntityTypes()
        //        .SelectMany(t => t.GetForeignKeys())
        //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        //    foreach(var fk in cascadeFKs)
        //    {
        //        fk.DeleteBehavior = DeleteBehavior.Restrict;
        //    }

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
