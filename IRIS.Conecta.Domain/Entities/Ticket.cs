using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }

        // Título de la Ponencia (S/A)
        public required string Title { get; set; }
        
        // Nombre de la actividad que origina la movilidad
        public string? EventName { get; set; }
        public required TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }
        
        #region Justificación

        // Convenio (S/A)
        public string? AgreementName { get; set; }

        // Objetivo de la solicitud
        public string? Description { get; set; }
        public bool? IsAgreement { get; set; } = false;
        public string? Results { get; set; }
        public DateOnly? DeliveryDate { get; set; }

        #endregion

        #region Movility

        // Tipo de Movilidad
        public string? MovilityType { get; set; }

        public string? Country { get; set; }
        public string? City { get; set; }

        public string? Phone { get; set; }

        public string? ContactData { get; set; }

        public string? ExternalInstitution { get; set; }

        public required string UserId { get; set; }

        public int PersonalDataId { get; set; }

        public int AcademicDataId { get; set; }

        // TODO: Fecha de movilidad y fecha de requerimientos son diferentes?
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        #endregion

        #region Requirements
        public TicketRequirements? TicketRequirements { get; set; } = null;

        public double? Total { get; set; }

        #endregion

        #region Relationships
        public required RequestType RequestType { get; set; }

        public virtual required PersonalData PersonalData { get; set; }

        public required AcademicData AcademicData { get; set; }


        #endregion
    }
}
