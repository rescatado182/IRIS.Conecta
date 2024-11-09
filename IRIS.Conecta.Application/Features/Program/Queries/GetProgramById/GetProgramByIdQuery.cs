using IRIS.Conecta.Application.Features.Program.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Queries.GetProgramById
{
    public class GetProgramByIdQuery : IRequest<ProgramDto>
    {
        public int Id { get; set; }
    }
}
