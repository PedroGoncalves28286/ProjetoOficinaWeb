using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Receptionist: IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string Firstname { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1}characters leght.")]
        public string Lastname { get; set; } 

        public string Adress { get; set; }

        public int PhoneNumber { get; set; }   

        public string ImageUrl { get; set; }
    }
}
