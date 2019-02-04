using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.API.Models;

namespace VehicleTracking.API.Repository
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetVehicles();
        List<Vehicle> GetVehicles(string type);
        Tire GetTireCondition(int Id);
        Fuel GetFuelPercentage(int Id);
    }
}
