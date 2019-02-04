using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.API.Models;

namespace VehicleTracking.API.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public Fuel GetFuelPercentage(int Id)
        {
            Fuel fuel = new Fuel();
            if (Id == 1)
            {
                 fuel = new Fuel
                {
                    VehicleId = 1,
                    Level = 100,
                    Type = "Gas"
                };
            }
            if (Id == 2)
            {
                fuel = new Fuel
                {
                    VehicleId = 2,
                    Level = 75,
                    Type = "Gas"
                };
            }
            if (Id == 3)
            {
                fuel = new Fuel
                {
                    VehicleId = 3,
                    Level = 50,
                    Type = "Gas"
                };
            }
            if (Id == 4)
            {
                fuel = new Fuel
                {
                    VehicleId = 4,
                    Level = 25,
                    Type = "Gas"
                };
            }
            if (Id == 5)
            {
                fuel = new Fuel
                {
                    VehicleId = 5,
                    Level = 10,
                    Type = "Gas"
                };
            }
            if (Id == 6)
            {
                fuel = new Fuel
                {
                    VehicleId = 6,
                    Level = 5,
                    Type = "Gas"
                };
            }

            return fuel;
        }

        public Tire GetTireCondition(int Id)
        {
            Tire tire = new Tire();

            if (Id == 1)
            {
                tire = new Tire
                {
                    VehicleId = 1,
                    Milage = 60000,
                    TredDepth = 10
                };
            }
            if (Id == 2)
            {
                tire = new Tire
                {
                    VehicleId = 2,
                    Milage = 50000,
                    TredDepth = 9
                };
            }
            if (Id == 3)
            {
                tire = new Tire
                {
                    VehicleId = 3,
                    Milage = 40000,
                    TredDepth = 8
                };
            }
            if (Id == 4)
            {
                tire = new Tire
                {
                    VehicleId = 4,
                    Milage = 30000,
                    TredDepth = 5
                };
            }
            if (Id == 5)
            {
                tire = new Tire
                {
                    VehicleId = 5,
                    Milage = 20000,
                    TredDepth = 3
                };
            }
            if (Id == 6)
            {
                tire = new Tire
                {
                    VehicleId = 6,
                    Milage = 10000,
                    TredDepth = 2
                };
            }

            return tire;
        }

        public List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>
            {
               new Vehicle
               {
                    Id=1,
                    Make="Merc",
                    Type = "Car",
                    Year = 2018,
                    Model = "Benz",
                    ImagePath = "https://www.google.com/search?q=car+images&rlz=1C1CHBF_enUS818US820&tbm=isch&source=iu&ictx=1&fir=0VP6_zAgcYtrBM%253A%252CSAT7jSghFpqMMM%252C_&usg=AI4_-kT75KY0LwHm4369ChcYR4eP8OhZbA&sa=X&ved=2ahUKEwisz_nSgqHgAhUHh-AKHW6SCFcQ9QEwAnoECAUQCA#imgrc=0VP6_zAgcYtrBM:"
               },
               new Vehicle
               {
                    Id=2,
                    Make="Ford",
                    Type = "Car",
                    Year = 2018,
                    Model = "Mustang"
               },
                new Vehicle
               {
                    Id=3,
                    Make="Mack",
                    Type = "Truck",
                    Year = 2018,
                    Model = "MackTruck"
               },
               new Vehicle
               {
                    Id=4,
                    Make="Dodge",
                    Type = "Truck",
                    Year = 2018,
                    Model = "RAM5000"
               },
                new Vehicle
               {
                    Id=5,
                    Make="Ducati",
                    Type = "Bike",
                    Year = 2018,
                    Model = "DucatiBike"
               },
               new Vehicle
               {
                    Id=6,
                    Make="Kawasaki",
                    Type = "Bike",
                    Year = 2018,
                    Model = "Ninja"
               },
            };

            return vehicles;
        }

        public List<Vehicle> GetVehicles(string type)
        {
            var vehicles = new List<Vehicle>();

            if (type == "Bike")
            {
                vehicles.Add(new Vehicle {
                    Id = 5,
                    Make = "Ducati",
                    Type = "Bike",
                    Year = 2018,
                    Model = "DucatiBike"
                });

                vehicles.Add(new Vehicle
                {
                    Id = 6,
                    Make = "Kawasaki",
                    Type = "Bike",
                    Year = 2018,
                    Model = "Ninja"
                });
            }

            if (type == "Car")
            {
                vehicles.Add(new Vehicle
                {
                    Id = 1,
                    Make = "Merc",
                    Type = "Car",
                    Year = 2018,
                    Model = "Benz"
                });

                vehicles.Add(new Vehicle
                {
                    Id = 2,
                    Make = "Ford",
                    Type = "Car",
                    Year = 2018,
                    Model = "Mustang"
                });
            }
            if (type == "Truck")
            {
                vehicles.Add(new Vehicle
                {
                    Id = 3,
                    Make = "Mack",
                    Type = "Truck",
                    Year = 2018,
                    Model = "MackTruck"
                });

                vehicles.Add(new Vehicle
                {
                    Id = 4,
                    Make = "Dodge",
                    Type = "Truck",
                    Year = 2018,
                    Model = "RAM5000"
                });
            }

            return vehicles;
        }
    }
}
