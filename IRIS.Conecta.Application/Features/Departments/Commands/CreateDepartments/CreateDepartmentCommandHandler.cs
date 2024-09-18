using AutoMapper;
using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateDepartmentCommandValidator(_departmentRepository);
            var validationResult = validator.ValidateAsync(request);

            if (!validationResult.IsCompletedSuccessfully)
            {
                throw new Exception("Invalid Faculty record");
            }

            var department = _mapper.Map<Department>(request);

            await _departmentRepository.CreateAsync(department);

            return department.Id;

        }

    }
}
