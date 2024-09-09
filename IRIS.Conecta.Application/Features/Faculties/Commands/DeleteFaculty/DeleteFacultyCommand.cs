using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.DeleteFaculty
{
    public class DeleteFacultyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
