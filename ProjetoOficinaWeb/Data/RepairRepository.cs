using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Migrations;
using ProjetoOficinaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public class RepairRepository : GenericRepository<Repair>, IRepairRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly UserManager<User> _userManager;

        public RepairRepository(DataContext context, IUserHelper userHelper, UserManager<User> userManager) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
            _userManager = userManager;
        }

        public IQueryable GetAllAppointments()
        {
            return _context.Repairs.Include(p => p.Id);
        }

        public IEnumerable<SelectListItem> GetComboAppointments()
        {
            var list = _context.Appointments.Select(s => new SelectListItem 
            {
                Text = s.AppointmentDate.ToString(), 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select an Appointment...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboVehicles()
        {
            var list = _context.Vehicles.Select(s => new SelectListItem 
            {
                Text = s.LicensePlate, 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a vehicle...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboMechanics()
        {
            var list = _context.Users.Select(s => new SelectListItem 
            {
                Text = s.FullName, 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a service...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboServices()
        {
            var list = _context.Vehicles.Select(s => new SelectListItem 
            {
                Text = s.LicensePlate, 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a vehicle...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRepair()
        {
            var list = _context.Vehicles.Select(s => new SelectListItem 
            {
                Text = s.LicensePlate, 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a vehicle...)",
                Value = "0"
            });

            return list;
        }

        //    public async Task<Repair> GetByIdRepairAsync(int id)
        //    {
        //        return await _context.Set<Repair>().AsNoTracking().Include(p => p.Mechanic.FullName)
        //            .Include(p => p.Vehicle.LicencePlate)
        //            .Include(p => p.Service.Description)
        //            .Include(p => p.Appointment.AppointmentDate)
        //            .FirstOrDefault(e => e.Id == id);
        //    }
    }
}
