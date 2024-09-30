using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.DeleteDepartment
{
    internal class DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository) : 
        IRequestHandler<DeleteDepartmentCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);

            if (department == null) {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            await _departmentRepository.DeleteAsync(department);

            return Unit.Value;
        }
    }
    
}

