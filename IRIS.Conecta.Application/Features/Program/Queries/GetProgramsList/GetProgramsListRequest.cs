using IRIS.Conecta.Application.Features.Program.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Queries.GetProgramsList
{
    public class GetProgramsListRequest : IRequest<List<ProgramDto>>
    {
    }
}
