using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public interface IProductrepository :IGenericRepository<Service>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboServices();
    }
}
