using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class ServiceViewModel : Service
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public int Price { get; set; }

        public User User { get; set; }
    }
}
