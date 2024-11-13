using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Features.Program.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.Program.Queries.GetProgramById
{
    public class GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, ProgramDto>
    {
        private readonly IMapper mapper;
        private readonly IProgramRepository programRepository;

        public GetProgramByIdQueryHandler(IMapper mapper, IProgramRepository programRepository)
        {
            this.mapper = mapper;
            this.programRepository = programRepository;
        }

        public async Task<ProgramDto> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var program = await this.programRepository.GetProgramwithDetail(request.Id);

            return this.mapper.Map<ProgramDto>(program);
        }
    }
}
