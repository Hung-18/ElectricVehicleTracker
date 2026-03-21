using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IElectricVehicleRepository
    {
        Task<IEnumerable<ElectricVehicle>> GetAllVehicleAsync();
        Task<ElectricVehicle?> GetVehicleByIdAsync(Guid id);
        Task AddVehicleAsync(ElectricVehicle vehicle);
        Task UpdateVehicle(ElectricVehicle vehicle);
        Task<bool> DeleteVehicleAsync(Guid id);
        Task<List<ElectricVehicle>> PageResultAsync(int page, int pageSize);
        Task<int> CountAsync();
    }
}
