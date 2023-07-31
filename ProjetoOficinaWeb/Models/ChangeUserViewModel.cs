using Microsoft.AspNetCore.Http;
using ProjetoOficinaWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Models
{
    public class ChangeUserViewModel : User
    {
        //[Required]
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }

        //[Required]
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }

        //[Required]
        //public string Address { get; set; }

        //[Required]
        //[Display(Name = "Phone Number")]
        //public int PhoneNumber { get; set; }

        //[Required]
        //[Display(Name = "Tax Number")]
        //public int TaxNumber { get; set; }

        //[Required]
        //[Display(Name = "Postal Code")]
        //public string PostalCode { get; set; }


        // IMAGEM
        public IFormFile ImageFile { get; set; }

        //        public string ImageUrl { get; set; }
    }
}
