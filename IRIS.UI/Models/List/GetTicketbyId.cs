using System.ComponentModel.DataAnnotations;
using TabBlazor;

namespace IRIS.UI.Models.List
{
    public class GetTicketbyIdVM
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string UserId { get; set; }

        public string ManagerUserId { get; set; }


        public string ManagerUserName { get; set; }

        public string UserName { get; set; }

        public int personalDataId { get; set; }

        public int academicDataId { get; set; }

        ////Datos Personas
        //public string FullName { get; set; }

        //public string DocumentNumber { get; set; }

        //public string DocumentType { get; set; }

        //public string BornCountry { get; set; }

        //public string BornState { get; set; }

        //public string BornCity { get; set; }

        //public string ResidenceState { get; set; }
        //public string ResidenceCity { get; set; }
        //public string AddressResidence { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public string Cellphone { get; set; }


        ////Datos Academicos

        //public string FacultyName { get; set; }

        //public string ProgramName { get; set; }

        //public string ResearchProject { get; set; }

        //public string AverageCredit { get; set; }

        //public string ProgramType { get; set; }

        //public string ResearchGroup { get; set; }

        //public string IsInstitutionalGroup { get; set; }


        ////Tipo de Movilidad



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
        public DateTime DateCreated { get; set; }

        // crear campo concatenado con los campos  AgreementName, EventName, Title, descrition

        public string Busqueda
        {
            get { return AgreementName + " " + EventName + " " + Title + " " + Description; }
        }




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


        public string MovilityTypeDisplayName => GetDisplayNameForMovilityType(MovilityType);

        // Función para obtener el DisplayName de TicketsStatus
        private string GetDisplayNameForMovilityType(string status)
        {
            if (Enum.TryParse(status, out EnumMovilityType parsedStatus))
            {
                return parsedStatus.GetDisplayName();
            }
            return string.Empty; // Devuelve vacío si no se puede obtener el nombre
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
