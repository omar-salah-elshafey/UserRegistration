using AutoMapper;
using UserRegistration.Data;
using UserRegistration.Models;

namespace UserRegistration.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.Addresses, opt => opt.MapFrom(src =>  src.Addresses))
                .ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<RegistrationModel, User>()
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ReverseMap();

            CreateMap<User, ResponseModel>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(a => new AddressDto
                {
                    Governate = a.Governate,
                    City = a.City,
                    Street = a.Street,
                    BuildingNumber = a.BuildingNumber,
                    FlatNumber = a.FlatNumber
                })))
                .ReverseMap();

        }
    }
}
