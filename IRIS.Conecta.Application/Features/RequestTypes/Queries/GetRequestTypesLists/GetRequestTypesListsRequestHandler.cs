using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists
{
    public class GetRequestTypesListsRequestHandler : 
        IRequestHandler<GetRequestTypesListsRequest, List<RequestTypesListDto>>
    {
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly IMapper _mapper;

        public GetRequestTypesListsRequestHandler(
            IRequestTypeRepository requestTypeRepository, 
            IMapper mapper)
        {
            _requestTypeRepository  = requestTypeRepository;
            _mapper                 = mapper;
        }

        public async Task<List<RequestTypesListDto>> Handle(GetRequestTypesListsRequest request, CancellationToken cancellationToken)
        {
            var requestTypes = await _requestTypeRepository.GetRequestTypesListWithDeparments();

            var academicRequests = _mapper.Map<List<RequestTypesListDto>>(requestTypes);

            return academicRequests;
        }
    }
}
