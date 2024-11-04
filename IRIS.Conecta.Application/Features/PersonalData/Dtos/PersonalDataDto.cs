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
        public int BornStateId { get; set; }
        public int BornCityId { get; set; }
        public int ResidenceStateId { get; set; }
        public int ResidenceCityId { get; set; }
        public string AddressResidence { get; set; }
        public string PersonalEmail { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
    }
}
