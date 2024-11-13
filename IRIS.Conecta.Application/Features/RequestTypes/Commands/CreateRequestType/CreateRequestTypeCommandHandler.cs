using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType
{
    public class CreateRequestTypeCommandHandler : IRequestHandler<CreateRequestTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRequestTypeRepository _requestTypeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CreateRequestTypeCommandHandler(IMapper mapper, 
            IRequestTypeRepository requestTypeRepository,
            IDepartmentRepository departmentRepository)
        {
            _mapper                 = mapper;
            _departmentRepository   = departmentRepository;
            _requestTypeRepository  = requestTypeRepository;            
        }
        public async Task<int> Handle(CreateRequestTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var validator = new CreateRequestTypeCommandValidator(_departmentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Request Type", validationResult);

            // Mapping data
            var requestType = _mapper.Map<RequestType>(request);

            // Create record
            await _requestTypeRepository.CreateAsync(requestType);

            return requestType.Id;
        }
    }
}
