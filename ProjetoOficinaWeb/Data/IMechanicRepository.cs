using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public interface IMechanicRepository : IGenericRepository<Mechanic>
    {
        public IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboMechanics();
    }



}
