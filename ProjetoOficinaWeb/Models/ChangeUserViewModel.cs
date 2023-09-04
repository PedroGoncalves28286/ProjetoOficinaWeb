using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Models
{
    public class ChangeUserViewModel
    {
       
        
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
        
    }
}
