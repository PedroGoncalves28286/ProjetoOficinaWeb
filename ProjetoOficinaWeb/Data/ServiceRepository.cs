using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Services.Include(s => s.User);
        }

        public IEnumerable<SelectListItem> GetComboServices()
        {
            var list = _context.Services.Select(s => new SelectListItem
            {
                Text = s.Description,
                Value = s.Id.ToString(),
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text ="(select a service...)",
                Value = "0"
            });
            return list;
        }
    }
}
