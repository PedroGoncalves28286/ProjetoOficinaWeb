using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class VehicleViewModel : Vehicle
    {
        [Display(Name = "Name")]
        public IFormFile ImageFile { get; set; }
    }
}
