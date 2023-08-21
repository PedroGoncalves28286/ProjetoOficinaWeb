using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class VehicleRepository :GenericRepository<Vehicle>, IVehicleRepository

    {
        public VehicleRepository(DataContext context) : base(context) { }   
    }
}
