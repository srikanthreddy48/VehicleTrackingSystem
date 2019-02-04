using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.API.Models
{
    public class Fuel
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }
    }
}
