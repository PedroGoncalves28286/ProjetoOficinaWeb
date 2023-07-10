using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;
        public SeedDb(DataContext context)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Mechanic");
            await _userHelper.CheckRoleAsync("Receptionist");

            var user = await _userHelper.GetUserByEmailAsync("Pedro.Goncalves.28286@formandos.cinel.pt"); 
            if (user == null) // se nao existir
            {
                user = new User
                {
                    FirstName = "Pedro",
                    LastName = "Gonçalves",
                    Email = "Pedro.Goncalves.28286@formandos.cinel.pt",
                    UserName = "Pedro.Goncalves.28286@formandos.cinel.pt",
                    PhoneNumber = "914038992",
                    ImageUrl = ""
                };

                var result = await _userHelper.AddUserAsync(user, "123456789");
                if (result != IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
               
            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }


            if (!_context.Services.Any())
            {

               
                AddService("Electrónica", 100);
                AddService("Alinhamento direcção", 600);
                AddService("Ar condicionado", 800);
                AddService("Bateria", 50);
                AddService("embraiagem", 400);
                AddService("sistema de escape ", 250);
                AddService("pneus", 100);
                AddService("travões", 180);
                AddService("mudança de oleo", 30);
                AddService("luzes", 30);
                AddService("mudança de filtros", 30);
                AddService("afinação", 90);
                AddService("outros", 1000);

                await _context.SaveChangesAsync();

            }
        }

        private void AddService(string descripton, int price)
        {
            _context.Services.Add(new Service
            {
                Description = descripton,
                Price = _random.Next(1000),

            });
        }
    }
}
