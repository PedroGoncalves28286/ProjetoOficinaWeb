using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public class ProductRepository :GenericRepository <Service>,IProductrepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) :base(context)
        {
            _context = context;
        }

        public IQueryable getAllWithUsers()
        {
            return _context.Services.Include(s => s.User);
        }

        public IQueryable GetAllWithUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetComboServices()
        {
            var list = _context.Services.Select(s => new SelectListItem {

                Text = s.Description,
                Value = s.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Service...)",
                Value = "0"
            });

            return list;
        }
    }
}
