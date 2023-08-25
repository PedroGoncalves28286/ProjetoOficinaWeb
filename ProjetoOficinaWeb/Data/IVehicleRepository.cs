using System.Linq;
using ProjetoOficinaWeb.Data.Entities;


namespace ProjetoOficinaWeb.Data
{
    public interface IVehicleRepository :IGenericRepository<Vehicle>
    {
        public IQueryable GetAllWithUsers();
    }
}
