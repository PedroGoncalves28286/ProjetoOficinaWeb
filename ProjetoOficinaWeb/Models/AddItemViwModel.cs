using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjetoOficinaWeb.Models
{
    public class AddItemViewModel 
    {

        [Display(Name = "Vehicle")]
        [Range(1, int.MaxValue, ErrorMessage = "Tem de selecionar um veiculo.")] 
        public int VehicleId { get; set; }

        [Display(Name = "Service")]
        [Range(1, int.MaxValue, ErrorMessage = "Tem de selecionar um serviço.")] 
        public int ServiceId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "A quantidade tem de ser um numero positiva ")]
        public double Quantity { get; set; } 

        public IEnumerable<SelectListItem> Services { get; set; }  

        public IEnumerable<SelectListItem> Vehicles { get; set; }  
    }
}
