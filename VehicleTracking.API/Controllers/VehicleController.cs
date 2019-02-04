using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTracking.API.Models;
using VehicleTracking.API.Repository;

namespace VehicleTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(_vehicleRepository.GetVehicles());
        }


        [HttpGet("type")]
        public IActionResult GetVehicles(string type)
        {
            return Ok(_vehicleRepository.GetVehicles(type));
        }

        [HttpGet]
        [Route("fuel")]
        public IActionResult GetFuelPercentage(int Id)
        {
            return Ok(_vehicleRepository.GetFuelPercentage(Id));
        }

        //[HttpPost]
        //public IActionResult UpdateFuelPercentage([FromBody] Fuel)
        //{
        //    return Ok();
        //}

        [HttpGet]
        [Route("tire")]
        public IActionResult GetTirePressure(int Id)
        {
            return Ok(_vehicleRepository.GetTireCondition(Id));
        }

        //[HttpPost]
        //public IActionResult UpdateTirePressure([FromBody] Fuel)
        //{
        //    return Ok();
        //}
    }
}