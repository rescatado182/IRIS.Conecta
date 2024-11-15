using TabBlazor;

namespace IRIS.UI.Models.List
{
    public class TicketManageListVM
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public string Department { get; set; }
        public string RequestName { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateOnly CreateDate { get; set; }

        public string TicketStatusDisplayName => GetDisplayNameForTicketStatus(Status);

        // Función para obtener el DisplayName de TicketsStatus
        private string GetDisplayNameForTicketStatus(string status)
        {
            if (Enum.TryParse(status, out TicketsStatus parsedStatus))
            {
                return parsedStatus.GetDisplayName();
            }
            return string.Empty; // Devuelve vacío si no se puede obtener el nombre
        }

        public TablerColor GetTicketStatusColor()
        {
            return Status.ToLower() switch
            {
                "open" => TablerColor.Red,      // Abierto - Rojo
                "inprocess" => TablerColor.Purple, // En Proceso - Morado
                "committee" => TablerColor.Orange, // En Comité - Naranja
                "closed" => TablerColor.Green,   // Cerrado - Verde
                "Resolved" => TablerColor.Yellow,
                _ => TablerColor.Pink            // Default
            };
        }

        //public string GetTicketStatusColor()
        //{
        //    return Status.ToLower() switch
        //    {
        //        "Open" => "Red",      // Abierto - Rojo
        //        "InProcess" => "Purple", // En Proceso - Morado Amarillo
        //        "Committee" => "Orange", // En Comité - Naranja
        //        "Closed" => "Green",   // Cerrado - Verde
        //        _ => "Yellow"            // Default
        //    };
        //}

    }
}
