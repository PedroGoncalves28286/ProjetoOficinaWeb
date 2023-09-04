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


        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantity must be a positive number..")]
        public double Quantity { get; set; }


        public IEnumerable<SelectListItem> Services { get; set; }   
    }
}
