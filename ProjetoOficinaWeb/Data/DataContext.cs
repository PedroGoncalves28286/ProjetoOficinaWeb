using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class DataContext : DbContext
    {
        internal object Services;

        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
    }
}
