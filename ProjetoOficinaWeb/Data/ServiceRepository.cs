using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoOficinaWeb.Data
{
    public class ServiceRepository 
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        { 
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboServices()
        {
            var list = _context.Services.Select(s => new SelectListItem
            {
                Text = s.Description, 
                Value = s.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Selecione um serviço :)",
                Value = "0"
            });

            list.Insert(0, new SelectListItem
            {
                Text = "(Selecione um servico...)",
                Value = "0"
            });

            return list;
        }
    }
}
