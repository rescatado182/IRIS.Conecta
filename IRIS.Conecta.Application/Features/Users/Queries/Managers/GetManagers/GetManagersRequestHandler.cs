using AutoMapper;
using IRIS.Conecta.Application.Contracts.Identity;
using IRIS.Conecta.Application.Exceptions;
using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.Queries.Managers.GetManagers
{
    public class GetManagersRequestHandler : IRequestHandler<GetManagersRequest, List<Student>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public GetManagersRequestHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<List<Student>> Handle(GetManagersRequest request, CancellationToken cancellationToken)
        {
            var managers = await _userService.GetManagers();

            if (managers == null)
            {
                throw new NotFoundException(nameof(managers), request);
            }

            return _mapper.Map<List<Student>>(managers);
        }
    }
}
