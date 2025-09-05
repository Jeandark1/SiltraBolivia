using AutoMapper;
using CargoApi.Application.DTOs;
using CargoApi.Domain.Entities;

namespace CargoApi.Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            // Mapeos para DataUser  
              
            CreateMap<CreateUserRequestDto, DataUser>();
            CreateMap<UpdateUserRequestDto, DataUser>();
            CreateMap<DataUser, UserResponseDto>()
                .ForMember(dest => dest.ClientInfo, opt => opt.MapFrom(src => src.DataClient))
                .ForMember(dest => dest.CompanyInfo, opt => opt.MapFrom(src => src.DataCompany))
                .ForMember(dest => dest.DriverInfo, opt => opt.MapFrom(src => src.Driver));
            // linea
            CreateMap<DataUser, CreateUserRequestDto>().ReverseMap();
            /*
            // Mapeos para DataClient
            CreateMap<DataClient, ClientInfoDto>();

            // Mapeos para DataCompany
            CreateMap<DataCompany, CompanyInfoDto>();

            // Mapeos para Driver
            CreateMap<Driver, DriverInfoDto>();   */

            /*
            // Mapeos para otras entidades (agregar según sea necesario)
            CreateMap<Vehicle, VehicleResponseDto>();
            CreateMap<CreateVehicleRequestDto, Vehicle>();
            CreateMap<UpdateVehicleRequestDto, Vehicle>();  */
        }
    }
}
