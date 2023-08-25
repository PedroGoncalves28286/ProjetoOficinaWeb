using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Vehicle :IEntity
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

        public DateTime Date { get; set; }

        public string Email { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }   


        public User User { get; set; }
        
        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return null;
                }
                return $"https://localhost:44350{ImageUrl.Substring(1)}";
            }
        }

       
    }
    
}