using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class User
    {
        internal string Email;

        public int Id { get; set; }

        [Required] 
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Address { get; set; }

        // [MaxLength(9, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public int TaxNumber { get; set; }

        public string PostalCode { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        public string ImageUrl { get; set; } 

        
    }
}
