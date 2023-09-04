using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }


        [Required]
        [Compare ("Password")]
        public string Confirm { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }






    }
}
