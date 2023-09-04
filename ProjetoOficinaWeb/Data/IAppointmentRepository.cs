using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboAppointments();

    }
}
