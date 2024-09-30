using AutoMapper;
using FluentValidation;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler :IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public UpdateDepartmentCommandHandler(IMapper mapper, 
            IDepartmentRepository departmentRepository,
            IFacultyRepository facultyRepository)
        {
            _mapper                 = mapper;
            _departmentRepository   = departmentRepository;
            _facultyRepository      = facultyRepository;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deparment = await _departmentRepository.GetByIdAsync(request.Id);

            if (deparment == null) {
                throw new NotFoundException(nameof(deparment), request.Id);
            }

            var validator = new UpdateDepartmentCommandValidator(_facultyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false) {
                throw new ValidationException(validationResult.Errors);
            }

            _mapper.Map(request, deparment);
            await _departmentRepository.UpdateAsync(deparment);

            return Unit.Value;
        }
    }
}
