using IRIS.Conecta.Domain.Base;
using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Domain.Entities.Tickets
{
    public class TicketsView : BaseEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }

        // Título de la Ponencia (S/A)
        public required string Title { get; set; }

        // Nombre de la actividad que origina la movilidad
        public string? EventName { get; set; }
        public required TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }

        public string? RequestName { get; set; }
        public string? Department { get; set; }
        public string? FacultyName { get; set; }

        public string? FullName { get; set; }

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

        public string? ManagerUserId { get; set; }

        public string? ManagerFullName { get; set; }

        public DateOnly StartDateMovility { get; set; }
        public DateOnly EndDateMovility { get; set; }

        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }

        #endregion

        #region Requirements
        public string? TicketRequirements { get; set; } = null;

        public double? Total { get; set; }

        #endregion
    }
}
