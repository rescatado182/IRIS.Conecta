using AutoMapper;
using IRIS.Conecta.Application.Features.Program.Commands.CreateProgram;
using IRIS.Conecta.Application.Features.Program.Commands.UpdateProgram;
using IRIS.Conecta.Application.Features.Program.Dtos;
using IRIS.Conecta.Domain.Entities.Masters;

namespace IRIS.Conecta.Application.MappingProfiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, ProgramDto>().ReverseMap();
            CreateMap<CreateProgramCommand, Program>();
            CreateMap<UpdateProgramCommand, Program>();
        }
    }
}
