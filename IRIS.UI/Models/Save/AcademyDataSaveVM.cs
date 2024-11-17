using IRIS.UI.Pages.BL.Tickets.Shared;

namespace IRIS.UI.Models.Save
{
    public class AcademyDataSaveVM
    {
        public int id { get; set; }
        public AcademicDataDto academicDataDto { get; set; }

        public class AcademicDataDto
        {
            public int ProgramId { get; set; }

            // Proyecto de Investigación
            public string ResearchProject { get; set; }
            public string ResearchGroup { get; set; }
            public EnumProgramType ProgramType { get; set; }

            //Promedio crédito
            public double AverageCredit { get; set; }
            public int EnrolledSemester { get; set; }

            public bool IsInstitutionalGroup { get; set; }
            public required string UserId { get; set; }
            public int TicketId { get; set; }
        }
    }
}
