using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.API.Models
{
    public class Tire
    {
        public int VehicleId { get; set; }
        public int Milage { get; set; }
        public int TredDepth { get; set; }

    }
}
