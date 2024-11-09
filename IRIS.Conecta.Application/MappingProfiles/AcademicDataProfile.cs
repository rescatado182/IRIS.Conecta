using AutoMapper;
using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using IRIS.Conecta.Domain.Entities;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class AcademicDataProfile : Profile
    {
        public AcademicDataProfile() 
        {
            CreateMap<AcademicData, AcademicDataDto>();
            CreateMap<AcademicData, AcademicDataListDto>();
        }
    }
}
