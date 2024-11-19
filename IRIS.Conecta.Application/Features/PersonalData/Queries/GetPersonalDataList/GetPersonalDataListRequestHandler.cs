using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataList
{
    public class GetPersonalDataListRequestHandler : IRequestHandler<GetPersonalDataListRequest, List<PersonalDataListDto>>
    {
        private readonly IMapper mapper;
        private readonly IPersonalDataRepository personalDataRepository;

        public GetPersonalDataListRequestHandler(IMapper mapper, IPersonalDataRepository personalDataRepository)
        {
            this.mapper = mapper;
            this.personalDataRepository = personalDataRepository;
        }

        public async Task<List<PersonalDataListDto>> Handle(GetPersonalDataListRequest request, CancellationToken cancellationToken)
        {
            // Query DB
            var personalData = await this.personalDataRepository.GetPersonalDatasAsync();

            // mapping data
            var data = this.mapper.Map<List<PersonalDataListDto>>(personalData);

            return data;
        }
    }
}
