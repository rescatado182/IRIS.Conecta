using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Faculties.Commands.DeleteFaculty;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.Commands.DeleteDepartments
{
    internal class DeleteDepartmentsCommandHandler : IRequestHandler<DeleteDepartmentsCommand, Unit>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentsCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Unit> Handle(DeleteDepartmentsCommand request, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(request.Id);

            if (department == null)
            {
                throw new Exception("Not found");
            }

            await _departmentRepository.DeleteAsync(department);

            return Unit.Value;
        }
    }
    
}

