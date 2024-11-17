using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IRIS.UI.Models.List
{
    public class AcademyDataDetailVM
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public string ResearchProject { get; set; }

        public double AverageCredit { get; set; }

        public string ProgramType { get; set; }

        public int EnrolledSemester { get; set; }


        public string ResearchGroup { get; set; }

        public bool IsInstitutionalGroup { get; set; }

        public int TicketId { get; set; }



    }
}
