using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.AcademicData.Dtos
{
    public class AcademicDataDto
    {
        public int ProgramId { get; set; }

        // Proyecto de Investigación
        public string ResearchProject { get; set; }
        public string ResearchGroup { get; set; }
        public ProgramType ProgramType { get; set; }

        //Promedio crédito
        public double AverageCredit { get; set; }
        public int EnrolledSemester { get; set; }
        
        public bool IsInstitutionalGroup { get; set; }
        public string UserId { get; set; }
        public int TicketId { get; set; }
    }
}
