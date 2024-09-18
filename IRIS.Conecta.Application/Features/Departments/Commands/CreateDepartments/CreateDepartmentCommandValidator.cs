using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments
{


    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private IDepartmentRepository departmentRepository;

        public CreateDepartmentCommandValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }


    }




}
