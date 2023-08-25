using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public class VehicleRepository :GenericRepository<Vehicle>, IVehicleRepository

    {
        private readonly DataContext _context;

        public VehicleRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Vehicles.Include(p => p.User);
        }
    }
}
