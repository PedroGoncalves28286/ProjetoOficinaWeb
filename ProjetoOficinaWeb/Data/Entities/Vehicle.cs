using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public int? Year { get; set; }

        public User Email { get; set; }

        public string UserId { get; set; }
    }
    
}