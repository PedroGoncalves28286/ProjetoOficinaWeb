using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

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
    }
}
