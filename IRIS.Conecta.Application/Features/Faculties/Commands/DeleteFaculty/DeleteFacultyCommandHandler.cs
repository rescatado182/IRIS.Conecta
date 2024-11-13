using IRIS.Conecta.Application.Contracts.Persistence.Masters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.Features.Faculties.Commands.DeleteFaculty
{
    public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand, Unit>
    {
        private readonly IFacultyRepository _facultyRepository;

        public DeleteFacultyCommandHandler(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }
        public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
        {
            var faculty = await _facultyRepository.GetByIdAsync(request.Id);

            if (faculty == null) {
                throw new Exception("Not found");
            }

            await _facultyRepository.DeleteAsync(faculty);

            return Unit.Value;
        }
    }
}
