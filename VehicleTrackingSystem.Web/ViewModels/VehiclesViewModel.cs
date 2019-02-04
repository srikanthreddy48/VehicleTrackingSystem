﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.Web.Models;

namespace VehicleTrackingSystem.Web.ViewModels
{
    public class VehiclesViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
    }
}
