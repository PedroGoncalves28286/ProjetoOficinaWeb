using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Models
{
    public class RepairViewModel : Repair
    {
        public IEnumerable<SelectListItem> Appointments { get; set; }

        public IEnumerable<Repair> RepairDate { get; set; }

        public IEnumerable<SelectListItem> Services { get; set; }

        public IEnumerable<SelectListItem> Vehicles { get; set; }

        public IEnumerable<SelectListItem> Users { get; set; }
    }
}
