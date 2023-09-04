using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public class MechanicRepository : GenericRepository<Mechanic>,IMechanicRepository
    {
        private readonly DataContext _context;

        public MechanicRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Mechanics.Include(m => m.User);
        }

        public IEnumerable<SelectListItem> GetComboMechanics()
        {
            var list = _context.Mechanics.Select(s => new SelectListItem
            {
                Text = s.Name,
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
