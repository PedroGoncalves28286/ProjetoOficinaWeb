using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Service :IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public int Price { get; set; }
    }
}
