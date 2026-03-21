using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepairHistoryPart
    {
        [Key]
        public Guid RepairPartId { get; private set; }
        public Guid RepairId { get; private set; }
        public Guid PartId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public RepairHistory RepairHistory { get; private set; }
        public ReplacementPart ReplacementPart { get; private set; }
    }
}
