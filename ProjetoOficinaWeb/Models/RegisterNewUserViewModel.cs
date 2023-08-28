using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Laste Name")]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Required]
        [Compare ("Password")]
        public string Confirm { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }






    }
}
