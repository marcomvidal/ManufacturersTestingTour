using System.Collections.Generic;
using Cars.Domain.Models;

namespace Cars.Domain.Seeds
{
    public static class DataSeed
    {
        public static Manufacturer[] Manufacturers
        { 
            get => new Manufacturer[]
            {
                new Manufacturer { Id = 1, Name = "Volkswagen" },
                new Manufacturer { Id = 2, Name = "Fiat" }
            };
        }

        public static Car[] Cars
        { 
            get => new Car[]
            {
                new Car { Id = 1, Model = "Gol", Speed = 100, ManufacturerId = 1 },
                new Car { Id = 2, Model = "Palio", Speed = 90, ManufacturerId = 2  },
                new Car { Id = 3, Model = "Fox", Speed = 120, ManufacturerId = 1  },
                new Car { Id = 4, Model = "Punto", Speed = 110, ManufacturerId = 2  },
            };
        }
    }
}