using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ProjetoOficinaWeb.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IMailHelper _mailHelper;
        private readonly IConfiguration _configuration;

        public ClientsController(UserManager<User> userManager, IUserHelper userHelper, IImageHelper imageHelper, IConverterHelper converterHelper, IMailHelper mailHelper, IConfiguration configuration)
        {
            _userManager = userManager;
            _userHelper = userHelper;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
            _mailHelper = mailHelper;
            _configuration = configuration;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            var userRolesViewModel = new List<UserWithRolesViewModel>();
            foreach (User user in users)
            {
                var model = new UserWithRolesViewModel();
               
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.PhoneNumber = user.PhoneNumber;
                model.Email = user.Email;
                userRolesViewModel.Add(model);
                model.ImageUrl = user.ImageUrl;


            }
            return View(userRolesViewModel);
        }

        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterClient(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if (user == null)
                {
                    var path = string.Empty;
                    if (model.Username != null && model.Username.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "Clients");
                    }
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.Lastname,
                       
                        ImageUrl = path
                    };

                    var result = await _userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return View(model);
                    }
                    await _userHelper.AddUserToRoleAsync(user, "Customer");

                    string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    string tokenLink = Url.Action("ConfirmEmail", "Account", new
                    {
                        userid = user.Id,
                        token = myToken,
                    }, protocol: HttpContext.Request.Scheme);

                    Response response = _mailHelper.SendEmail(model.FirstName, "Email confirmation", $"<h1>Email Confirmation</h1>" +
                        $"To allow the user, " +
                        $"please click in this link:</br></br><a href = \"{tokenLink}\">Confirm Email</a>");

                    if (response.IsSuccess)
                    {
                        ViewBag.Message = "The instructions to allow you user has been sent to email";
                        return View(model);
                    }

                    ModelState.AddModelError(string.Empty, "The user couldn't be logged.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if (user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(15),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return this.Created(string.Empty, results);

                    }
                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var user = await _userHelper.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userHelper.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
            }
            return View();
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(string id) // pode aceitar null
        {
            if (id == null)
            {
                return new NotFoundViewResult("Error404");
            }

            var customer = await _userHelper.GetUserByIdAsync(id);

            if (customer == null)
            {
                return new NotFoundViewResult("Error404");
            }

            var model = new RegisterNewUserViewModel();
            if (customer != null)
            {
                model.FirstName = customer.FirstName;
               
            }
            return View(customer);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            var user = await _userHelper.GetUserByIdAsync(id.ToString());
            var model = new RegisterNewUserViewModel();
            if (user != null)
            {
                model.FirstName = user.FirstName;
               
            }
            return View(model);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterNewUserViewModel model, string id)
        {
            if (!ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.Username != null && model.PhoneNumber.Length > 0)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile, "Clients");
                }
              

                var user = await _userHelper.GetUserByIdAsync(id.ToString());
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.ImageUrl = path;

                    user.ImageUrl = path;

                    var response = await _userHelper.UpdateUserAsync(user);
                    if (response.Succeeded)
                    {
                        ViewBag.UserMessage = "User updated!";
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }
                }
            }

            return View(model);
        }

        // GET: Clients/Delete/5 // Só mostra o que for para apagar. Não apaga
        public async Task<IActionResult> Delete(string? id) // O ? permite que o id seja opcional de forma a que mesmo que o id vá vazio (url) o programa não "rebente"
        {
            if (id == null)
            {
                return new NotFoundViewResult("Error404"); // passo a minha view ; genérico dá para produtos, clientes, fornecedores, etc
            }

            var client = await _userManager.FindByIdAsync(id);
            if (client == null)
            {
                return new NotFoundViewResult("Error404"); // passo a minha view ; genérico dá para produtos, clientes, fornecedores, etc
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")] // quando houver um action chamada "Delete" mas que seja com um Post faz o DeleteConfirmed
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) // o id é obrigatório
        {
            var client = await _userManager.FindByIdAsync(id); // o id é verficado para ver se ainda existe

            if (id == null)
            {
                return new NotFoundViewResult("Error404"); // passo a minha view ; genérico dá para produtos, clientes, fornecedores, etc
            }
            try
            {
                await _userManager.DeleteAsync(client);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("DELETE"))
                {
                    ViewBag.ErrorTitle = $"{client.Email} is being used!!";
                    ViewBag.ErrorMessage = $"{client.Email} it´s not possible to delete because there are appointments with this user.</br></br>";
                }

                return View("Error");
            }
        }
    }
}
