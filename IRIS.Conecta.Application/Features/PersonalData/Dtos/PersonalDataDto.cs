using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.PersonalData.Dtos
{
    public class PersonalDataDto
    {
        public string FullName { get; set; } = null;
        public string DocumentNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateOnly BirthDate { get; set; }
        public int BornCountryId { get; set; }
        public string Country_name { get; set; }
        public int BornStateId { get; set; }
        public int BornCityId { get; set; }
        public string City { get; set; }
        public int ResidenceStateId { get; set; }
        public string State_name { get; set; }
        public int ResidenceCityId { get; set; }
        public string ResidenceCity { get; set; }
        public string AddressResidence { get; set; }
        public string PersonalEmail { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string UserId { get; set; }
        public int TicketId { get; set; }
    }
}
