using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType
{
    public class UpdateRequestTypeCommandHandler : IRequestHandler<UpdateRequestTypeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRequestTypeRepository requestTypeRepository;
        private readonly IProgramRepository ProgramRepository;

        public UpdateRequestTypeCommandHandler(IMapper mapper, 
            IRequestTypeRepository requestTypeRepository,
            IProgramRepository ProgramRepository)
        {
            this.mapper = mapper;
            this.requestTypeRepository  = requestTypeRepository;
            this.ProgramRepository   = ProgramRepository;
        }
        public async Task<Unit> Handle(UpdateRequestTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incomming data
            var requestType = await this.requestTypeRepository.GetByIdAsync(request.Id);

            if (requestType is null) {
                throw new NotFoundException(nameof(requestType), request.Id);
            }

            var validator = new UpdateRequestTypeValidator(this.ProgramRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if ( !validationResult.IsValid ) {
                throw new ValidationException(validationResult);
            }

            // Mapping the data
            this.mapper.Map(request, requestType);
            await this.requestTypeRepository.UpdateAsync(requestType);


            return Unit.Value;
        }
    }
}
