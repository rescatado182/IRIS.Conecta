using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataById
{
    public class GetPersonalDataByIdRequestHandler : IRequestHandler<GetPersonalDataByIdRequest, GetPersonalDataDto>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalDataViewRepository _personalDataViewRepository;

        public GetPersonalDataByIdRequestHandler(IMapper mapper, IPersonalDataViewRepository personalDataViewRepository)
        {
            _mapper = mapper;
            _personalDataViewRepository = personalDataViewRepository;
        }
        public async Task<GetPersonalDataDto> Handle(GetPersonalDataByIdRequest request, CancellationToken cancellationToken)
        {
            var personalData = await _personalDataViewRepository.GetPersonalDataByIdAsync(request.Id);

            return _mapper.Map<GetPersonalDataDto>(personalData);
        }
    }
}
