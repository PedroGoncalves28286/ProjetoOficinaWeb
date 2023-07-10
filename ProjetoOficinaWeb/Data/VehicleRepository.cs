using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;

namespace ProjetoOficinaWeb.Data
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public VehicleRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Vehicles.Add(p => p.UserId); 
        }

        public void Task<IQueryable<Vehicle>> GetVehicleAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await _userHelper.IsUserInRoleAsync(user, "Receptionist")) 
            {
                return _context.Vehicles
                .Include(o => o.UserId) 
                
                .Include(o => o.LicensePlate); 
            }

            return _context.Vehicles 
                .Include(o => o.LicensePlate);
            
           
        }

        public void Task<Vehicle> GetVehicleAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public IEnumerable<SelectListItem> GetComboVehicles()
        {
            var list = _context.Vehicles.Select(p => new SelectListItem 
            {
                Text = p.LicensePlate,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select the car registration plate...)",
                Value = "0"
            });

            return list;
        }
    }
}
