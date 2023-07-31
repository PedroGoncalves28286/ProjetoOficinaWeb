using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class RegisterNewUserViewModel : User
    {
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
