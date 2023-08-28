using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System;

namespace ProjetoOficinaWeb.Helpers
{
    public interface IConverterHelper
    {
        Vehicle ToVehicle(VehicleViewModel model, Guid imageId, bool isNew);

        VehicleViewModel ToVehicleViewModel(Vehicle vehicle);
    }
}
