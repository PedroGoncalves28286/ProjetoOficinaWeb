using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IConverterHelper
    {
        Vehicle ToVehicle(VehicleViewModel model,string path, bool isNew);

        VehicleViewModel ToVehicleViewModel(Vehicle vehicle);
    }
}
