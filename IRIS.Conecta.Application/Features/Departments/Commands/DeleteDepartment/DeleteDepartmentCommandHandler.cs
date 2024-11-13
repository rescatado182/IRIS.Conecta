using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.DeleteDepartment
{
    internal class DeleteDepartmentCommandHandler(IDepartmentRepository DepartmentRepository) : 
        IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _DepartmentRepository = DepartmentRepository;

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _DepartmentRepository.GetByIdAsync(request.Id);

            if (Department == null) {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            await _DepartmentRepository.DeleteAsync(Department);

            return Unit.Value;
        }
    }
    
}

