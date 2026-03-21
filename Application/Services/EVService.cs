using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EVService : IElectricVehicleService
    {
        private readonly IElectricVehicleRepository _vehicleRepository;
        private readonly IMapper _iMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLog;

        public EVService(IElectricVehicleRepository vehicleRepository, IUnitOfWork unitOfWork, IMapper iMapper, IAuditLogService auditLog)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
            _iMapper = iMapper;
            _auditLog = auditLog;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehicleAsync()
        {
            var vehicle = await _vehicleRepository.GetAllVehicleAsync();
            return _iMapper.Map<IEnumerable<VehicleDTO>>(vehicle);
        }

        public async Task<VehicleDTO> GetVehicleByIdAsync(Guid id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            return _iMapper.Map<VehicleDTO>(vehicle);
        }

        public async Task AddVehicleAsync(CreateVehicleDTO createvehicleDto)
        {
            var vehicle = _iMapper.Map<ElectricVehicle>(createvehicleDto);
            await _vehicleRepository.AddVehicleAsync(vehicle);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task UpdateVehicleAsync(Guid id, UpdateVehicleDTO updateVehicleDto)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }
            _iMapper.Map(updateVehicleDto, vehicle);
            await _vehicleRepository.UpdateVehicle(vehicle);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteVehicleAsync(Guid id,Guid userId)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException("Vehicle not found");
            }
            await _vehicleRepository.DeleteVehicleAsync(id);
            await _unitOfWork.SaveChangeAsync();
            await _auditLog.LogAsync(userId,$"Delete Vehicle{id}");
        }
        public async Task<PageResult<VehicleDTO>> PageResultAsync(int page, int pageSize)
        {
            var vehicle = await _vehicleRepository.PageResultAsync(page, pageSize);
            var total = await _vehicleRepository.CountAsync();
            var data = _iMapper.Map<List<VehicleDTO>>(vehicle);
            return new PageResult<VehicleDTO>
            {
                Page = page,
                PageSize = pageSize,
                Total = total,
                Data = data
            };
        }
    }
}
