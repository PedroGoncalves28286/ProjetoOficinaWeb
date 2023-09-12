using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoOficinaWeb.Data
{
    public class RepairRepository :GenericRepository<Repair>, IRepairRepository
    {
        private readonly DataContext _context;

        public RepairRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Repairs.Include(m => m.User);
        }

        public IEnumerable<SelectListItem> GetComboRepairs()
        {
            var list = _context.Repairs.Select(r => new SelectListItem
            {
                Text = r.LicensePlate,
                Value = r.Id.ToString(),

            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Repair...)",
                Value = "0"
            });

            return list;

       
        }
    }
}
