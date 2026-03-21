using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; private set; }
        public Guid RepairId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string CreatedBy { get; private set; }
        public RepairHistory RepairHistory { get; private set; }
    }
}
