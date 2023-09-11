using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
