using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypeById
{
    public class GetRequestTypeByIdQueryHandler : IRequestHandler<GetRequestTypeByIdQuery, RequestTypesDto>
    {
        private readonly IMapper mapper;
        private readonly IRequestTypeRepository requestTypeRepository;

        public GetRequestTypeByIdQueryHandler(IMapper mapper, IRequestTypeRepository requestTypeRepository)
        {
            this.mapper                 = mapper;
            this.requestTypeRepository  = requestTypeRepository;
        }
        
        public async Task<RequestTypesDto> Handle(GetRequestTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var requestType = await this.requestTypeRepository.GetRequestTypeWithDeparment(request.Id);

            if (requestType == null) {
                throw new NotFoundException(nameof(requestType), request.Id);
            }

            return this.mapper.Map<RequestTypesDto>(requestType);
        }
    }
}
