using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Models;
using System;
using System.IO;

namespace ProjetoOficinaWeb.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Vehicle ToVehicle(VehicleViewModel model,Guid imageId, bool isNew)
        {
            return new Vehicle
            {
                Id = isNew ? 0 : model.Id, 
                ImageId = imageId,
                LicensePlate = model.LicensePlate,
                Brand = model.Brand,
                Model = model.Model,
                Color = model.Color,
                Date = model.Date,
                Email = model.Email,
                User = model.User

            };
        }

        public VehicleViewModel ToVehicleViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                Id = vehicle.Id,
                ImageId = vehicle.ImageId,  
                LicensePlate = vehicle.LicensePlate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Color = vehicle.Color,
                Date = vehicle.Date,
                Email = vehicle.Email,
                User = vehicle.User

            };
        }
    }
}
