namespace IRIS.Conecta.Application.Features.AcademicData.Dtos
{
    public class AcademicDataListDto
    {
        public int Id { get; set; }        
        // Proyecto de Investigación
        public string ResearchProject { get; set; }
        //Promedio crédito
        public string ResearchGroup { get; set; }
        public double AverageCredit { get; set; }
        public int EnrolledSemester { get; set; }
        public string Program { get; set; }

    }
}
