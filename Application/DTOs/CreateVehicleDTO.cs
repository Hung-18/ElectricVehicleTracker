using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreateVehicleDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public Guid TypeId { get; set; }
        public Guid UserId { get; set; }
        public double BatteryCapacity { get; set; }
        public double RangePerCharge { get; set; }
        public double ChargingTime { get; set; }
        public int StateOfHealth { get; set; }
        public int CurrentOdometer { get; set; }
    }
}
