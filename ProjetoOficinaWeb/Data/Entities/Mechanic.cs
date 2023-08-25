using System.ComponentModel.DataAnnotations;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class Mechanic : IEntity
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="the filed{0} can contain {1} characters lenght.")]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }

        public string Age { get; set; }

        public string Photo { get; set; }

        public User User { get; set; }



    }
}
