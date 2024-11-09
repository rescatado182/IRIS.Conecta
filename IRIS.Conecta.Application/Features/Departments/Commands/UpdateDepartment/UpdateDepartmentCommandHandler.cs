using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler :IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _DepartmentRepository;
        private readonly IFacultyRepository _facultyRepository;

        public UpdateDepartmentCommandHandler(IMapper mapper, 
            IDepartmentRepository DepartmentRepository,
            IFacultyRepository facultyRepository)
        {
            _mapper                 = mapper;
            _DepartmentRepository   = DepartmentRepository;
            _facultyRepository      = facultyRepository;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var deparment = await _DepartmentRepository.GetByIdAsync(request.Id);

            if (deparment == null) {
                throw new NotFoundException(nameof(deparment), request.Id);
            }

            var validator = new UpdateDepartmentCommandValidator(_facultyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false) {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, deparment);
            await _DepartmentRepository.UpdateAsync(deparment);

            return Unit.Value;
        }
    }
}
