using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

            var user = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Pedro",
                    LastName = "Goncalves",
                    Email = "pedromfonsecagoncalves@gmail.com",
                    UserName = "pedromfonsecagoncalves@gmail.com",
                    PhoneNumber = "914038992"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);


            }

            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");

            }

            if (!_context.Vehicles.Any())
            {
                AddVehicle("Mercedes", "C220 cdi", "Yellow", "42-FG-64", user);
                AddVehicle("Opel Corsa", "1.2 16v", "Red", "64-22-AA", user);
                AddVehicle("Renault Clio", "1.2 16v", "Green", "47-88-FF", user);


                await _context.SaveChangesAsync();
            }

            if (!_context.Services.Any())
            {
                AddService("Pintura ", 50, user);
                AddService("Bate-Chapa", 45, user);
                AddService("Mecânica", 60, user);
                AddService("Electricidade", 55, user);
                AddService("Electrónica", 47, user);

                await _context.SaveChangesAsync();

            }

            if (!_context.Repairs.Any())
            {
                AddRepair("Mercedes c220", "42-FG-64", "123456", DateTime.Now, "123458", "Artur Silva", "Mecanica", user);
                AddRepair("Opel Corsa", "64-22-AA", "678945", DateTime.Now, "555655", "Jose Artur", "Pintura", user);
                AddRepair("Renault Clio", "47-88-FF", "35647", DateTime.Now, "566566", "Joaquim Silva", "bate-chapa", user);

                await _context.SaveChangesAsync();


            }

            if (!_context.Appointments.Any())
            {
                AddAppointment("123458", DateTime.Now, "Reparação da caixa de velocidades", user);
                AddAppointment("555655", DateTime.Now, "Pintura Porta frente Esquerda", user);
                AddAppointment("566566", DateTime.Now, "Substituição de porta frente esquerda", user);

                await _context.SaveChangesAsync();
            }

            if (!_context.Mechanics.Any())
            {
                AddMechanic("Artur Silva", "Mecanico", "44", user);
                AddMechanic("Jose almeida", "Pintor", "55", user);
                AddMechanic("Rui Jorge", "Bate-chapa", "64", user);

                await _context.SaveChangesAsync();
            }

        }

        private void AddMechanic(string name, string specialization, string age, User user)
        {
            _context.Mechanics.Add(new Mechanic
            {
                Name = name,
                Specialization = specialization,
                Age = age,
                User = user

            });


        }

        private void AddAppointment(string appointmentId, DateTime date, string subject, User user)
        {
            _context.Appointments.Add(new Appointment
            {
                AppointmentId = appointmentId,
                Date = date,
                Subject = subject,
                User = user

            });
        }

        private void AddService(string description, int price, User user)
        {
            _context.Services.Add(new Service
            {
                Description = description,
                Price = price,
                User = user

            });
        }

        private void AddRepair(string Vehicle, string licencePlate, string serviceId, DateTime appointment, string appointmentId, string mechanic, string service, User user)
        {
            _context.Repairs.Add(new Repair
            {
                Vehicle = Vehicle,
                LicensePlate = licencePlate,
                ServiceId = serviceId,
                Appointment = appointment,
                AppointmentId = appointmentId,
                Mechanic = mechanic,
                Service = service,
                User = user
            });

        }


        private void AddVehicle(string brand, string model, string color, string licencePlate, User user)
        {
            _context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = model,
                Color = color,
                LicensePlate = licencePlate,
                User = user

            });
        }
    }
}
