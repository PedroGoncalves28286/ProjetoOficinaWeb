using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboAppointments();

        Task RepairOrder(RepairViewModel model);


    }
}
