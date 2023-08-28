using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }

        public IActionResult login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");   
            }
            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index", "Home");
                }
            }
            this.ModelState.AddModelError(string.Empty, "Failed to login");
            return View(model);

            
        }
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.UserName);
                if(user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName= model.LastName,
                        Email= model.UserName,
                        UserName = model.UserName 

                    };

                    var result = await _userHelper.AddUserAsync(user , model.Password);
                    if(result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "the user couldn´t be created.");
                        return View(model);
                    }

                    var loginviewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        UserName = model.UserName
                    };
                    var result2 = await _userHelper.LoginAsync(loginviewModel);
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "the user couldn´t be logged."); 
                }
               
            }
            return View(model);

        }
    }
}
