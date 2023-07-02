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

        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

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
