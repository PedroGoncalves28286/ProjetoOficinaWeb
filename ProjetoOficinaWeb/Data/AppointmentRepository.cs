using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository 
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public AppointmentRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task AddItemToAppointmentAsync(AddItemViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return;
            }

            var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
            if (vehicle == null)
            {
                return;
            }

            var service = await _context.Services.FindAsync(model.ServiceId);
            if (service == null)
            {
                return;
            }

            var appointmentDetailTemp = await _context.AppointmentDetailsTemp
                .Where(apt => apt.User == user && apt.Vehicle == vehicle && apt.Service == service)
                .FirstOrDefaultAsync();

            if (appointmentDetailTemp == null)
            {
                appointmentDetailTemp = new AppointmentDetailTemp
                {
                    Price = service.Price,
                    Vehicle = vehicle,
                    Service = service,
                    Quantity = model.Quantity,
                    User = user,
                };

                _context.AppointmentDetailsTemp.Add(appointmentDetailTemp);
            }
            else
            {
                appointmentDetailTemp.Quantity += model.Quantity;
                _context.AppointmentDetailsTemp.Update(appointmentDetailTemp);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ConfirmAppointmentAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return false;
            }

            var appointmentTmps = await _context.AppointmentDetailsTemp
                .Include(o => o.Vehicle)
                .Include(s => s.Service)
                .Where(o => o.User == user)
                .ToListAsync();

            if (appointmentTmps == null || appointmentTmps.Count == 0)
            {
                return false;
            }

            var details = appointmentTmps.Select(o => new AppointmentDetail
            {
                Price = o.Price,
                Vehicle = o.Vehicle,
                Service = o.Service,
                Quantity = o.Quantity
            }).ToList();

            var appointment = new Appointment
            {
                AppointmentDate = DateTime.UtcNow,
                User = user,
                Items = details
            };

            await CreateAsync(appointment);
            _context.AppointmentDetailsTemp.RemoveRange(appointmentTmps);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task DeleteDetailTempAsync(int id)
        {
            var appointmentDetailTemp = await _context.AppointmentDetailsTemp.FindAsync(id);
            if (appointmentDetailTemp == null)
            {
                return;
            }

            _context.AppointmentDetailsTemp.Remove(appointmentDetailTemp);
            await _context.SaveChangesAsync();
        }


        public async Task RepairOrder(RepairViewModel model)
        {
            var appointment = await _context.Appointments.FindAsync(model.Id);
            if (appointment == null)
            {
                return;
            }

            //  appointment.RepairDate = model.RepairDate;
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<AppointmentDetailTemp>> GetDetailTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            return _context.AppointmentDetailsTemp
                .Include(v => v.Vehicle)
                .Include(s => s.Service)
                .Where(o => o.User == user)
                .OrderBy(o => o.Vehicle.LicensePlate);
        }


        public async Task<IQueryable<Appointment>> GetAppointmentAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await _userHelper.IsUserInRoleAsync(user, "Admin")) 
            {
                return _context.Appointments
                    .Include(o => o.User)
                    .Include(o => o.Items)
                    .ThenInclude(v => v.Vehicle) 
                    .OrderByDescending(o => o.AppointmentDate);
            }

            return _context.Appointments 
                .Include(o => o.Items)
                .ThenInclude(p => p.Vehicle)
                //.ThenInclude(s => s.Service)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.AppointmentDate);
        }

        public async Task<Appointment> GetAppointmentAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task ModifyAppointmentDetailTempQuantityAsync(int id, double quantity)
        {
            var appointmentDetailTemp = await _context.AppointmentDetailsTemp.FindAsync(id);
            if (appointmentDetailTemp == null)
            {
                return;
            }

            appointmentDetailTemp.Quantity += quantity;
            if (appointmentDetailTemp.Quantity > 0)
            {
                _context.AppointmentDetailsTemp.Update(appointmentDetailTemp);
                await _context.SaveChangesAsync();
            }
        }

    }
}
