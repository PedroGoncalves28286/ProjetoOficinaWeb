using Microsoft.AspNetCore.Identity;

namespace ProjetoOficinaWeb.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
         
         
    }

}

