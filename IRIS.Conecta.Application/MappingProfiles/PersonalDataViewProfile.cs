using AutoMapper;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class PersonalDataViewProfile : Profile
    {
        public PersonalDataViewProfile()
        {
            CreateMap<PersonalDataView, GetPersonalDataDto>();
            CreateMap<PersonalDataView, PersonalDataListDto>();
        }
    }
}
