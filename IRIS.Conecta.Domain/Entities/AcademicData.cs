using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Entities.Masters;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IRIS.Conecta.Domain.Entities
{
    public class AcademicData : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProgramId { get; set; }
        // Proyecto de Investigación
        public string? ResearchProject { get; set; }
        public ProgramType ProgramType { get; set; }
        //Promedio crédito
        public double AverageCredit { get; set; }
        public int EnrolledSemester { get; set; }
        public string? ResearchGroup { get; set; }
        public bool IsInstitutionalGroup { get; set; }
        public required string UserId { get; set; }
        public int? TicketId { get; set; }
        
        #region Relationships

        [JsonIgnore]
        public virtual Program? Program { get; set; }
        public virtual Ticket? Ticket { get; set; }

        #endregion
    }
}
