using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IElectricVehicleService
    {
        Task<IEnumerable<VehicleDTO>> GetAllVehicleAsync();
        Task AddVehicleAsync(CreateVehicleDTO createVehicleDto);
        Task UpdateVehicleAsync(Guid id, UpdateVehicleDTO updateVehicleDto);
        Task DeleteVehicleAsync(Guid id,Guid userId);
        Task<VehicleDTO> GetVehicleByIdAsync(Guid id);
        Task<PageResult<VehicleDTO>> PageResultAsync(int page, int pageSize);
    }
}
