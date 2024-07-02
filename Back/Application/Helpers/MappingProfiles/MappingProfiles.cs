using Application.Categories;
using Application.Dtos;
using Application.Guests;
using AutoMapper;
using Domain;

namespace Application.Helpers.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedByUser.FullName));
        CreateMap<Guest, GuestDto>()
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedByUser.FullName))
            .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.LastUpdatedByUser.FullName));

        CreateMap<CarLoad, CarLoadDto>()
            .ForMember(dest => dest.Sprint, opt => opt.MapFrom(src => src.Sprint.Name))
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client))
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Name))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name))
            .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Type));
        CreateMap<Sprint, SprintDto>()
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedByUser.FullName))
            .ForMember(dest => dest.LastUpdatedBy, opt => opt.MapFrom(src => src.LastUpdatedByUser.FullName))
            .ForMember(dest => dest.NumberCarLoad, opt => opt.MapFrom(src => src.CarLoads.Count));
    }
}