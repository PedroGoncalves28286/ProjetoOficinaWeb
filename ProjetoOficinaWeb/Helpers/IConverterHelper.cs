using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IConverterHelper
    {
        Vehicle ToVehicle(VehicleViewModel model, string path, bool isNew); 

        VehicleViewModel ToVehicleViewModel(Vehicle vehicle);

        Service ToService(ServiceViewModel model, string path, bool isNew); 

        ServiceViewModel ToServiceViewModel(Service service);

        Repair ToRepair(RepairViewModel model, string path, bool isNew); 

        RepairViewModel ToRepairViewModel(Repair repair);
    }
}

