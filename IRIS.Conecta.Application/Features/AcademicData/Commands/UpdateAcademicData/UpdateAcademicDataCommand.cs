using IRIS.Conecta.Domain.Enums;
using MediatR;

namespace IRIS.Conecta.Application.Features.AcademicData.Commands.UpdateAcademicData
{
    public class UpdateAcademicDataCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string ResearchProject { get; set; }
        public string ResearchGroup { get; set; }
        public ProgramType ProgramType { get; set; }
        public double AverageCredit { get; set; }
        public int EnrolledSemester { get; set; }
        public bool IsInstitutionalGroup { get; set; }
        public string UserId { get; set; }
        public int TicketId { get; set; }

    }
}
