using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.Queries.Students.GetStudents
{
    public class GetStudentsRequest : IRequest<List<Student>>
    {
    }
}
