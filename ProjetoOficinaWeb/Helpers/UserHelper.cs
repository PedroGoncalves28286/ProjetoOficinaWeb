using Microsoft.AspNetCore.Identity;
using ProjetoOficinaWeb.Data.Entities;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;

        public UserHelper(UserManager<User>userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult>AddUserAsync(User user , string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
