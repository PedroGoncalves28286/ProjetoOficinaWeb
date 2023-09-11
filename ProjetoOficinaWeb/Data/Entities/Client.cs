using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Client : IEntity
    {

        public int Id { get; set; } 
        [Required]
        [MaxLength (50,ErrorMessage = "the field {0} can contain {1} characters.")]
        public string  FIrstName { get; set; }

       

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string Adress { get; set; }  

        public ICollection<Client> Clients { get; set; }    

        public int PhoneNumber { get; set; }

        public string ImageUrl { get; set; }


    }
}
