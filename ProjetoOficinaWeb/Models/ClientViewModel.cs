using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "ID")]
        [MaxLength(50, ErrorMessage = "The field{0}  can contain {1} characters")]
        public string Name { get; set; }
    }
}
