using System.Web;
namespace ProjetoOficinaWeb.Data.Entities 
{
    public class Mechanic : IEntity

    { 



        public int Id { get; set; } 

        public string Name { get; set; }   
        
        public string Specialization { get; set; }  

        public string Age { get; set; } 

        public string Photo { get; set; }

        

    }
}
