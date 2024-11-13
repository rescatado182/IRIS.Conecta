using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Features.Program.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Queries.GetProgramsList
{
    public class GetProgramsListRequestHandler : IRequestHandler<GetProgramsListRequest, List<ProgramDto>>
    {
        private readonly IMapper mapper;
        private readonly IProgramRepository programRepository;

        public GetProgramsListRequestHandler(IMapper mapper, IProgramRepository programRepository)
        {
            this.mapper = mapper;
            this.programRepository = programRepository;
        }
        public async Task<List<ProgramDto>> Handle(GetProgramsListRequest request, CancellationToken cancellationToken)
        {
            // Query database
            var programs = await this.programRepository.GetProgramswithDetails();

            // Convert objects into dtos
            var data = this.mapper.Map<List<ProgramDto>>(programs);

            return data;
        }
    }
}
