using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class EVProfile : Profile
    {
        public EVProfile()
        {
            CreateMap<CreateVehicleDTO, ElectricVehicle>()
    .ConstructUsing(src => new ElectricVehicle(
        Guid.NewGuid(), // Tạo ID mới cho xe
        src.Brand,
        src.Model,
        src.Year,
        src.BatteryCapacity,
        src.RangePerCharge,
        src.ChargingTime,
        src.StateOfHealth,
        src.CurrentOdometer,
        DateTime.UtcNow,
        DateTime.UtcNow
    ))
    // PHẢI CÓ 2 DÒNG NÀY: Để AutoMapper tìm đến field private và ghi đè vào
    .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId))
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));


            CreateMap<UpdateVehicleDTO, ElectricVehicle>();
            CreateMap<ElectricVehicle, VehicleDTO>();

            CreateMap<RegisterUserDTO, User>().ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
