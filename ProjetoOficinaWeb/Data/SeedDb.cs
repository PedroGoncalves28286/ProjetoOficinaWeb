using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjetoOficinaWeb.Data.Entities;
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
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Vehicles.Any())
            {
                AddVehicle("Mercedes", "C220 cdi" ,"Yellow","42-FG-64");
                AddVehicle("Opel Corsa" ,"1.2 16v" ,"Red" ,"64-22-AA");
                AddVehicle("Renault Clio" ,"1.2 16v" ,"Green" , "47-88-FF");
                

                await _context.SaveChangesAsync();
            }

            if (!_context.Services.Any())
            {
                AddService("Pintura " ,50);
                AddService("Bate-Chapa", 45);
                AddService("Mecânica" ,60 );
                AddService("Electricidade" ,55 );
                AddService("Electrónica", 47 );

                await _context.SaveChangesAsync();

            }

            if (!_context.Repairs.Any())
            {
                AddRepair("Mercedes c220","42-FG-64", "123456",DateTime.Now,"123458","Artur Silva","Mecanica");
                AddRepair("Opel Corsa","64-22-AA" , "678945",DateTime.Now,"555655" , "Jose Artur","Pintura");
                AddRepair("Renault Clio","47-88-FF","35647" ,DateTime.Now ,"566566","Joaquim Silva","bate-chapa");

                await _context.SaveChangesAsync();


            }

            if ( !_context.Appointments.Any())
            {
                AddAppointment("123458",DateTime.Now ,"Reparação da caixa de velocidades");
                AddAppointment("555655" ,DateTime.Now,"Pintura Porta frente Esquerda");
                AddAppointment("566566", DateTime.Now, "Substituição de porta frente esquerda");

                await _context.SaveChangesAsync();
            }

            if (!_context.Mechanics.Any())
            {
                AddMechanic("Artur Silva","Mecanico" ,"44");
                AddMechanic("Jose almeida", "Pintor", "55");
                AddMechanic("Rui Jorge", "Bate-chapa", "64");

                await _context.SaveChangesAsync();
            }

        }

        private void AddMechanic(string name,string specialization,string age)
        {
            _context.Mechanics.Add(new Mechanic
            {
                Name = name,
                Specialization = specialization,
                Age = age

            });


        }

        private void AddAppointment(string appointmentId ,DateTime date,string subject)
        {
            _context.Appointments.Add(new Appointment
            {
                AppointmentId = appointmentId,
                Date = date,
                Subject = subject

            });
        }

        private void AddService(string description, int price)
        {
            _context.Services.Add(new Service
            {
                Description = description,
                Price =price 

            });
        }

        private void AddRepair(string Vehicle,string licencePlate, string serviceId,DateTime appointment,string appointmentId,string mechanic, string service)
        {
            _context.Repairs.Add(new Repair
            {
                Vehicle = Vehicle,
                LicensePlate =licencePlate,
                ServiceId = serviceId,
                Appointment = appointment,
                AppointmentId = appointmentId,
                Mechanic = mechanic,
                Service = service  
            });
            
        }

       
        private void AddVehicle( string brand,string model, string color, string licencePlate)
        {
            _context.Vehicles.Add(new Vehicle
            {
                Brand = brand,
                Model = model,
                Color = color,
                LicensePlate = licencePlate  
                
            });
        }
    }
}
