using ProjetoOficinaWeb.Data.Entities;
using System.Collections.Generic;

namespace ProjetoOficinaWeb.Models
{
    public class UserWithRolesViewModel :User
    {
        public List<string> Roles { get; set; }

        public User User { get; set; }

        public string UserListUrl { get; set; }
    }
}
