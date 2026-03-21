using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepairHistory
    {
        [Key]
        public Guid RepairId { get; private set;}
        public Guid ElectricVehicleId { get; private set; }
        public DateTime RepairDate { get; private set; }
        public string Description { get; private set; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; }
        public ElectricVehicle ElectricVehicle { get; private set; }
        public ICollection<RepairHistoryPart> Parts { get; private set; } = new List<RepairHistoryPart>();
        public Payment Payment { get; private set; }
    }
}
