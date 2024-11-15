using IRIS.Conecta.Application.Models.Identity;
using MediatR;

namespace IRIS.Conecta.Application.Features.Users.GetStudentById
{
    public class GetUserByIdRequest : IRequest<Student>
    {
        public string UserId { get; set; }
    }
}
