using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(Guid userId, string action);
    }
}
