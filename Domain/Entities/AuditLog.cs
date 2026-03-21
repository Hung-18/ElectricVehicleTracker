using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuditLog
    {
        [Key]
        public Guid LogId { get; private set; }
        public Guid UserId { get; private set; }
        public string Action { get; private set; }
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;
        public User User { get; private set; }

        public AuditLog(Guid userId, string action, DateTime timestamp)
        {
            LogId = Guid.NewGuid();
            UserId = userId;
            Action = action;
            Timestamp = timestamp;
        }
    }
}
