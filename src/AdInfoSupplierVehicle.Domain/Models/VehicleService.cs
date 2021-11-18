using AdInfoSupplierVehicle.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdInfoSupplierVehicle.Domain.Models
{
    public class VehicleService
    {
        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleService(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void Create(Vehicle vehicle)
        {
            Vehicle respVehicle = new Vehicle();
            if (vehicle != null && vehicle.Id != null)
            {
                respVehicle = _vehicleRepository.GetById(vehicle.Id.Value);
            }

            if (respVehicle == null)
            {
                respVehicle = vehicle;
                _vehicleRepository.Save(respVehicle);
            }
        }
    }
}
