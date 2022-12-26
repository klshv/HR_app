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
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<ContactData, ContactDataDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<PersonCreateDto, Person>();

            CreateMap<Applicant, ApplicantDto>().ReverseMap();
            CreateMap<ApplicantCreateDto, Applicant>();
            CreateMap<ApplicantEntity, Applicant>().ReverseMap();
            CreateMap<Applicant, ApplicantShortDto>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeShortDto>();

        }
    }
}
