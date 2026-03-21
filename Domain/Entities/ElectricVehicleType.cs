using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ElectricVehicleType
    {
        [Key]
        public Guid ElectricVehicleTypeId { get;private set; }
        public string TypeName { get;private set; }

        public ICollection<ElectricVehicle> Vehicles { get;private set; } = new List<ElectricVehicle>();
    }
}
