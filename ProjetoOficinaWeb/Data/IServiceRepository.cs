using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public interface IServiceRepository :IGenericRepository<Service>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboServices();
    }
}
