using AutoMapper;
using IRIS.Conecta.Application.Features.Facutlties.DTOs;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class FacultiesProfile : Profile
    {
        public FacultiesProfile()
        {
            CreateMap<Faculty, FacultiesDto>().ReverseMap();
        }
    }
}
