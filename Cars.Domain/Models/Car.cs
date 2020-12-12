using Newtonsoft.Json;
using System;

namespace Cars.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        
        [JsonIgnore]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public void Accelerate()
        {
            if (Speed > 210)
                throw new InvalidOperationException();
            
            Speed += 10;
        }

        public void Brake()
        {
            if (Speed < 10)
                throw new InvalidOperationException();
            
            Speed -= 10;
        }
    }
}
