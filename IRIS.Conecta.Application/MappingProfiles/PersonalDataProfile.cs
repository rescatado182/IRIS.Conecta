using AutoMapper;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class PersonalDataProfile : Profile
    {
        public PersonalDataProfile()
        {
            CreateMap<PersonalData, PersonalDataDto>().ReverseMap();
            CreateMap<PersonalData, PersonalDataListDto>();
        }
    }
}
