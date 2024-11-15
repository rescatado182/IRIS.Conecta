using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.Queries.Managers.GetManagers
{
    public class GetManagersRequest : IRequest<List<Student>>
    {
    }
}
