using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Models
{
    public class AddItemViewModel
    {
        [Display(Name = "Licence plate")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Licence Plate.")]
        public int ServiceId { get; set; }

        public IEnumerable<SelectListItem> Service { get; set; }   
    }
}
