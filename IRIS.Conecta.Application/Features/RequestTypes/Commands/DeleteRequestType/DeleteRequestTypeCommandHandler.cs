using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.RequestTypes.Commands.DeleteRequestType
{
    public class DeleteRequestTypeCommandHandler : IRequestHandler<DeleteRequestTypeCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRequestTypeRepository requestTypeRepository;

        public DeleteRequestTypeCommandHandler(IMapper mapper, IRequestTypeRepository requestTypeRepository)
        {
            this.mapper = mapper;
            this.requestTypeRepository = requestTypeRepository;
        }
        public async Task<Unit> Handle(DeleteRequestTypeCommand request, CancellationToken cancellationToken)
        {
            var requestType = await this.requestTypeRepository.GetByIdAsync(request.Id);

            if (requestType == null) {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            await this.requestTypeRepository.DeleteAsync(requestType);

            return Unit.Value;
        }
    }
}
