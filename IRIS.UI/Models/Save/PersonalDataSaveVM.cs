namespace IRIS.UI.Models.Save
{

    public class PersonalDataSaveVM
    {
        public int id { get; set; }
        public PersonalDataDto personalDataDto { get; set; }
        public class PersonalDataDto
        {
            
            public string FullName { get; set; } = null;
            public string DocumentNumber { get; set; }
            public EnumDocumentType DocumentType { get; set; }
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
            public string UserId { get; set; }
            public int TicketId { get; set; }

        }
    }
}
