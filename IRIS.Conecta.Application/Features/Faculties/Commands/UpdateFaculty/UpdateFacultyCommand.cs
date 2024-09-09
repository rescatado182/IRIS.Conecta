using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.UpdateFaculty
{
    public class UpdateFacultyCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
