using AutoMapper;
using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.Queries.Students.GetStudents
{
    public class GetStudentsRequestHandler : IRequestHandler<GetStudentsRequest, List<Student>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetStudentsRequestHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<Student>> Handle(GetStudentsRequest request, CancellationToken cancellationToken)
        {
            var students = await _userService.GetStudents();

            if (students == null)
            {
                throw new NotFoundException(nameof(students), request);
            }

            return _mapper.Map<List<Student>>(students);
        }
    }
}
