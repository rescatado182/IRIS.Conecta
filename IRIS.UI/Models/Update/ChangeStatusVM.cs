using TabBlazor;

namespace IRIS.UI.Models.Update
{
    public class ChangeStatusVM
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ManagerUserId { get; set; }

        public string Status { get; set; }

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
    }

}

