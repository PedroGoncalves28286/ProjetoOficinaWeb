using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;


namespace ProjetoOficinaWeb.Models
{
    public class ServiceViewModel : Service
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}

