using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ElectricVehicleRepository : IElectricVehicleRepository
    {
        private readonly AppDBContext _context;
        public ElectricVehicleRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ElectricVehicle>> GetAllVehicleAsync()
        {
            return await _context.ElectricVehicles.AsNoTracking().ToListAsync();
        }
        public async Task<ElectricVehicle?> GetVehicleByIdAsync(Guid id)
        {
            return await _context.ElectricVehicles.FindAsync(id);
        }
        public async Task AddVehicleAsync(ElectricVehicle vehicle)
        {
            await _context.ElectricVehicles.AddAsync(vehicle);
        }

        public Task UpdateVehicle(ElectricVehicle vehicle)
        {
            _context.ElectricVehicles.Update(vehicle);
            return Task.CompletedTask;
        }

        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            var vehicle = await _context.ElectricVehicles.FindAsync(id);
            if (vehicle == null) return false;
            _context.ElectricVehicles.Remove(vehicle);
            return true;
        }

        public async Task<List<ElectricVehicle>> PageResultAsync(int page, int pageSize)
        {
            return await _context.ElectricVehicles.AsNoTracking()
                .Skip((page-1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.ElectricVehicles.CountAsync();
        }
    }

}
