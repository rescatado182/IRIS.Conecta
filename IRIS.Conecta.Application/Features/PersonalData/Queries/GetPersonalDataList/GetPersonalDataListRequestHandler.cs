using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataList
{
    public class GetPersonalDataListRequestHandler : IRequestHandler<GetPersonalDataListRequest, List<PersonalDataListDto>>
    {
        private readonly IMapper mapper;
        private readonly IPersonalDataViewRepository personalDataViewRepository;

        public GetPersonalDataListRequestHandler(IMapper mapper, IPersonalDataViewRepository personalDataViewRepository)
        {
            this.mapper = mapper;
            this.personalDataViewRepository = personalDataViewRepository;
        }

        public async Task<List<PersonalDataListDto>> Handle(GetPersonalDataListRequest request, CancellationToken cancellationToken)
        {
            // Query DB
            var personalData = await this.personalDataViewRepository.GetPersonalDatasAsync();

            // mapping data
            var data = this.mapper.Map<List<PersonalDataListDto>>(personalData);

            return data;
        }
    }
}
