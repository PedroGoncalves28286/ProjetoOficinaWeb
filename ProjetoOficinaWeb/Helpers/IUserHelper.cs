using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email); 

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model); 

        Task LogoutAsync();

        Task CheckRoleAsync(string roleName); 

        Task AddUserToRoleAsync(User user, string roleName); 

        Task<bool> IsUserInRoleAsync(User user, string roleName); 

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserByIdAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<IdentityResult> UpdateUserAsync(User user); 

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<User> GetUserAsync(string id);

        IEnumerable<SelectListItem> GetComboUsers();
    }
}
