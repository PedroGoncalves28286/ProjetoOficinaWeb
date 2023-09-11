using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class RegisterNewUserViewModel :User
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [MaxLength(100, ErrorMessage = "the field {0} only can contain {1} characters lenght.")]
        public string AAddress { get; set; }

        [MaxLength(20, ErrorMessage ="the field {0} only can contain {1}characters length")]
        public string PhoneNumber { get; set; }

        public IFormFile ImageFile { get; set; }



        [Required]
        [Compare ("Password")]
        public string Confirm { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }






    }
}
