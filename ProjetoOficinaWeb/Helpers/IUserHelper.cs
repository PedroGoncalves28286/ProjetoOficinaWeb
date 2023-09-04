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

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);
        Task <bool>IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> ValidatePasswordAsync(User user , string password);

        Task<string> GenerateEmailConfirmationTokeAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userid);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
    }
}
