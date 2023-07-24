using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Vehicle ToVehicle(VehicleViewModel model, string path, bool isNew)
        {
            return new Vehicle
            {
                Id = model.Id,
                ImageUrl = path,
                LicensePlate = model.LicensePlate,
                Brand = model.Brand,
                Model = model.Model,
                Color = model.Color,
                Year = model.Year,
                UserId = model.UserId.ToString()
            };
        }

        public VehicleViewModel ToVehicleViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                Id = vehicle.Id,
                ImageUrl = vehicle.ImageUrl,
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Year = vehicle.Year,
                UserId = vehicle.UserId
            };
        }

        public Service ToService(ServiceViewModel model, string path, bool isNew)
        {
            return new Service
            {
                Id = model.Id,
                Description = model.Description,
                Price = model.Price,
            };
        }

        public ServiceViewModel ToServiceViewModel(Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Description = service.Description,
                Price = service.Price,
            };
        }

        public Repair ToRepair(RepairViewModel model, string path, bool isNew)
        {
            return new Repair
            {
                Id = model.Id,
                Vehicle = model.Vehicle,
                Service = model.Service,
                Appointment = model.Appointment,
                Mechanic = model.Mechanic
            };
        }

        public RepairViewModel ToRepairViewModel(Repair repair)
        {
            return new RepairViewModel
            {
                Id = repair.Id,
                Vehicle = repair.Vehicle,
                Appointment = repair.Appointment,
                Mechanic = repair.Mechanic
            };
        }
    }
}
