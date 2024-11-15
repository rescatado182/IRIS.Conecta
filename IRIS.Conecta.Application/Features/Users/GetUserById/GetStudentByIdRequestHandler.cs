using AutoMapper;
using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.GetStudentById
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, Student>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetUserByIdRequestHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Student> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }

            return _mapper.Map<Student>(user);
        }
    }
}
