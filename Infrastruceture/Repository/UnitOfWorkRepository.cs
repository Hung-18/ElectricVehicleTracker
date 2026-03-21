using Application.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly AppDBContext _context;
        public UnitOfWorkRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
