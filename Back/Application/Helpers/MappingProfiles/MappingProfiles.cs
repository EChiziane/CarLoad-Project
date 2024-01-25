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
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Name))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.Name))
            .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.Material.Type))
            .ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src.Expenses));
    }
}