using AutoMapper;
using HR_app.App.Domain;
using HR_app.Data.Entities;
using HR_app.Models.Dto;

namespace HR_app
{
    public class HRAppAutoMapperProfile : Profile
    {
        public HRAppAutoMapperProfile()
        {
            CreateMap<PersonEntity, Person>().ReverseMap();
            CreateMap<ContactDataEntity, ContactData>().ReverseMap();
            CreateMap<AddressEntity, Address>().ReverseMap();

            CreateMap<Person, PersonShortDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.GetFullName()));
            CreateMap<Person, PersonDto>();
            CreateMap<ContactData, ContactDataDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<PersonCreateDto, Person>();
        }
    }
}
