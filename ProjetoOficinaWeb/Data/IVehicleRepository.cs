
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;


namespace ProjetoOficinaWeb.Data
{
    public interface IVehicleRepository :IGenericRepository<Vehicle>
    {
        public IQueryable GetAllWithUsers();
        
        IEnumerable<SelectListItem> GetComboVehicles();  
    }
}
