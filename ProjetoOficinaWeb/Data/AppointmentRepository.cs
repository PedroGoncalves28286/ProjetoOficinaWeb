using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public class AppointmentRepository : GenericRepository<Appointment>,IAppointmentRepository
    {
        private readonly DataContext _context;

        public AppointmentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Appointments.Include(m => m.User);
        }

        public IEnumerable<SelectListItem> GetComboAppointments()
        {
            var list = _context.Appointments.Select(s => new SelectListItem
            {
                Text = s.Subject,
                Value = s.Id.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(select a service...)",
                Value = "0"
            });
            return list;
        }

        IQueryable IAppointmentRepository.GetAllWithUsers()
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<SelectListItem> IAppointmentRepository.GetComboAppointments()
        {
            throw new System.NotImplementedException();
        }

        Task IAppointmentRepository.RepairOrder(RepairViewModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
