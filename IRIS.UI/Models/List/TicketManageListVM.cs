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
        public string ManagerUserId { get; set; }
        public string ManagerName { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        public TablerColor TicketStatusColor
        {
            get
            {
                var daysDiff = (DateTime.Now - DateCreated).Days;

                if (daysDiff <= 1)
                {
                    return TablerColor.Green; 
                }
                else if (daysDiff <= 15)
                {
                    return TablerColor.Warning;
                }
                else
                {
                    return TablerColor.Red;
                }
            }
        }


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
                "open" => TablerColor.Red,     
                "inprocess" => TablerColor.Purple,
                "cancelled" => TablerColor.Orange, 
                "closed" => TablerColor.Green,   
                "resolved" => TablerColor.Yellow,
                _ => TablerColor.Pink           
            };
        }

        //public TablerColor GetDateStatusColor()
        //{
        //    var dateDiff = DateTime.Now.Date - DateCreated.ToDateTime(TimeOnly.MinValue);
        //    return dateDiff.Days < 15 ? TablerColor.Green :
        //           (dateDiff.Days <= 30 ? TablerColor.Yellow : TablerColor.Red);
        //}

        //// Propiedad para el texto del semáforo
        //public string GetDateStatusText()
        //{
        //    var dateDiff = DateTime.Now.Date - DateCreated.ToDateTime(TimeOnly.MinValue);
        //    return dateDiff.Days < 15 ? "Green" :
        //           (dateDiff.Days <= 30 ? "Yellow" : "Red");
        //}


    }
}
