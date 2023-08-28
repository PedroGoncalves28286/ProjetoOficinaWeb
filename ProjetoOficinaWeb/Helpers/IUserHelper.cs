using Microsoft.AspNetCore.Identity;
using ProjetoOficinaWeb.Data.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IUserHelper
    {
        Task<User>GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
