using Microsoft.AspNetCore.Identity;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(UserManager<User>userManager ,SignInManager <User>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult>AddUserAsync(User user , string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync
                (model.UserName,
                model.Password, model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
