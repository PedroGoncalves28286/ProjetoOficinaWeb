using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;

namespace ProjetoOficinaWeb.Models
{
    public class UserWithRolesViewModel 
    {
        public List<string> Roles { get; set; }

        public User User { get; set; }

        public string UserListUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set; }
    }
}
