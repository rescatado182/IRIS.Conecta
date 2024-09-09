using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
