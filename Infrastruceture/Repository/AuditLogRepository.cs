using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class AuditLogRepository : IAuditLogService
    {
        private readonly AppDBContext _context;
        public AuditLogRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task LogAsync(Guid userId, string action)
        {
            var log = new AuditLog(userId, action, DateTime.Now);
            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
