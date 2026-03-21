using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReplacementPart
    {
        [Key]
        public Guid PartId { get; private set; }
        public string PartName { get; private set; }
        public decimal Price { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<RepairHistoryPart> RepairHistoryParts { get; private set; } = new List<RepairHistoryPart>(); 
    }
}
