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
        public Guid ImageId { get; set; }

        public DateTime Date { get; set; }

        public string Email { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }   


        public User User { get; set; }

        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://projetooficinaweb.azurewebsites.net/images/no_image.png"
            : $"https://oficinaarmazenamento.blob.core.windows.net/vehicles/{ImageId}";

       
    }
    
}