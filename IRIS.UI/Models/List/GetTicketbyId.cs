using System.ComponentModel.DataAnnotations;
using TabBlazor;

namespace IRIS.UI.Models.List
{
    public class GetTicketbyIdVM
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string DateCreated { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public string ManagerUserId { get; set; }

        public string ManagerUser { get; set; }



        //Datos Personas
        public string FullName { get; set; }

        public string DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public string BornCountry { get; set; }

        public string BornState { get; set; }

        public string BornCity { get; set; }

        public string ResidenceState { get; set; }
        public string ResidenceCity { get; set; }
        public string AddressResidence { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }





        public string Title { get; set; }

        public string EventName { get; set; }

        

        public int RequestTypeId { get; set; }

        public string AgreementName { get; set; }

        public string AgreementType { get; set; }

        public string Description { get; set; }

        public bool IsAgreement { get; set; }

        public string Results { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string MovilityType { get; set; }

        public string Country { get; set; }

        public string City { get; set; }


        public string PostalCode { get; set; }

        public string CountryCode { get; set; }

        public string CityCode { get; set; }

        public string ContactData { get; set; }

        public string ExternalInstitution { get; set; }


        public DateTime StartDateMovility { get; set; }

        public DateTime EndDateMovility { get; set; }

        public DateTime StartDateRelease { get; set; }

        public DateTime EndDateRelease { get; set; }



        //public List<TicketRequirement> TicketRequirements { get; set; }

        public decimal Total { get; set; }

        public string StatusDisplayName
        {
            get
            {
                if (Enum.TryParse(typeof(TicketsStatus), Status, out var enumValue))
                {
                    return ((TicketsStatus)enumValue).GetDisplayName();
                }
                return "Estado desconocido"; // Fallback
            }
        }

        public TablerColor GetTicketStatusColor()
        {
            return Status.ToLower() switch
            {
                "open" => TablerColor.Red,
                "inprocess" => TablerColor.Purple,
                "cancelled" => TablerColor.Orange,
                "closed" => TablerColor.Green,
                "resolved" => TablerColor.Yellow,
                _ => TablerColor.Pink
            };
        }

    }
}
