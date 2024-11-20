using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Dtos
{
    public class TicketsListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AgreementName { get; set; }
        public string EventName { get; set; }
        public TicketsStatus Status { get; set; }
        public string RequestTypeId { get; set; }
        public string RequestName { get; set; }
        public string Department { get; set; }
        public string FacultyName { get; set; }
        public string Description { get; set; }
        public bool IsAgreement { get; set; } = false;
        public string Results { get; set; }
        public DateOnly DeliveryDate { get; set; }

        public string MovilityType { get; set; }
        public string Country { get; set; }
        public string country_name { get; set; }
        public string City { get; set; }

        public required string UserId { get; set; }

        public string FullName { get; set; }
        public string ManagerUserId { get; set; }

        public string ManagerUser { get; set; }

        public DateOnly StartDateMovility { get; set; }
        public DateOnly EndDateMovility { get; set; }

        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
