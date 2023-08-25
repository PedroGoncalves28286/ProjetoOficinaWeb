using Microsoft.AspNetCore.Identity;
using ProjetoOficinaWeb.Data.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IUserHelper
    {
        Task<User>GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);  
    }
}
