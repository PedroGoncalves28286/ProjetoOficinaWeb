using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]

        public string Token { get; set; }
    }
}
