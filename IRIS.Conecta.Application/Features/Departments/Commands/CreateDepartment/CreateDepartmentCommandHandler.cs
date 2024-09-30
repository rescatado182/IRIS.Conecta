using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Domain.Entities.Masters;
using MediatR;

namespace IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IDepartmentRepository _departmentRepository;
        
        private readonly IMapper _mapper;
        private readonly IFacultyRepository _facultyRepository;

        public CreateDepartmentCommandHandler(IMapper mapper,
            IFacultyRepository facultyRepository,
            IDepartmentRepository departmentRepository)
        {
            _facultyRepository      = facultyRepository;
            _departmentRepository   = departmentRepository;
            _mapper                 = mapper;
            
        }
        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateDepartmentCommandValidator(_facultyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Department", validationResult);

            // Mapping data
            var department = _mapper.Map<Department>(request);

            // Create record
            await _departmentRepository.CreateAsync(department);
            
            return department.Id;
        }

    }
}
