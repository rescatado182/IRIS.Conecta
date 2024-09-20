using MediatR;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty
{
    public class CreateFacultyCommand : IRequest<int>
    {
        public string FacultyName { get; set; } = string.Empty;
    }
}
