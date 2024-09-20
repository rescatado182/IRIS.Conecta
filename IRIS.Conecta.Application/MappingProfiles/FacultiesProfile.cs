using AutoMapper;
using IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty;
using IRIS.Conecta.Application.Features.Faculties.Commands.UpdateFaculty;
using IRIS.Conecta.Application.Features.Faculties.Dtos;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class FacultiesProfile : Profile
    {
        public FacultiesProfile()
        {
            CreateMap<FacultiesDto, Faculty>().ReverseMap();
            CreateMap<Faculty, FacultiesListDto>();
            CreateMap<CreateFacultyCommand, Faculty>();
            CreateMap<UpdateFacultyCommand, Faculty>();
        }
    }
}
