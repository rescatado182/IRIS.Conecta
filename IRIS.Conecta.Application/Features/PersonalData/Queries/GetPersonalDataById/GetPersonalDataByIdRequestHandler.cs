using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataById
{
    public class GetPersonalDataByIdRequestHandler : IRequestHandler<GetPersonalDataByIdRequest, PersonalDataDto>
    {
        private readonly IMapper _mapper;
        private readonly IPersonalDataRepository _personalDataRepository;

        public GetPersonalDataByIdRequestHandler(IMapper mapper, IPersonalDataRepository personalDataRepository)
        {
            _mapper = mapper;
            _personalDataRepository = personalDataRepository;
        }
        public async Task<PersonalDataDto> Handle(GetPersonalDataByIdRequest request, CancellationToken cancellationToken)
        {
            var personalData = await _personalDataRepository.GetByIdAsync(request.Id);

            return _mapper.Map<PersonalDataDto>(personalData);
        }
    }
}
