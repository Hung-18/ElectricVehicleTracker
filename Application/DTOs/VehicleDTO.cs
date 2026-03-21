using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VehicleDTO
    {
        public Guid VehicleId { get; set; }
        public string Brand {  get; set; }
        public string Model { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

    }
}
