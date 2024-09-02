using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists
{
    public class GetRequestTypesListsRequestHandler : IRequestHandler<GetRequestTypesListsRequest, List<RequestTypesDTO>>
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly IMapper _mapper;

        public GetRequestTypesListsRequestHandler(IRequestTypeRepository requestTypeRepository, IMapper mapper)
        {
            _requestTypeRepository = requestTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<RequestTypesDTO>> Handle(GetRequestTypesListsRequest request, CancellationToken cancellationToken)
        {
            var requestTypes = await _requestTypeRepository.GetAsync();

            var academicRequests = _mapper.Map<List<RequestTypesDTO>>(requestTypes);

            return academicRequests;
        }
    }
}
