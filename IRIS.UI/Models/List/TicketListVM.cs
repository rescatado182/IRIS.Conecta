namespace IRIS.UI.Models.List
{
    public class TicketListVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; }
        public int RequestTypeId { get; set; }
        public string AgreementName { get; set; }
        public string Description { get; set; }
        public bool IsAgreement { get; set; }
        public string Results { get; set; }
        public DateTime DeliveryDate { get; set; } // Asumiendo que lo manejas como DateTime
        public string MovilityType { get; set; } // Cambia esto a un enum si tienes tipos definidos
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string ContactData { get; set; }
        public string ExternalInstitution { get; set; }
        public DateOnly StartDate { get; set; } // Cambia a DateTime si lo manejas así
        public DateOnly EndDate { get; set; } // Cambia a DateTime si lo manejas así
       // public string TicketRequirements { get; set; }
        public decimal Total { get; set; } // Asumiendo que lo manejas como decimal
    }
}
