using DocumentFormat.OpenXml.Wordprocessing;
using IRIS.UI.Models.Enums;
using TabBlazor;

namespace IRIS.UI.Models.Save
{
    public class NotificationVM
    {
        public string Message { get; set; } = string.Empty;
        public bool SendEmail { get; set; }
        public int TicketId { get; set; }

        public string NotificationType { get; set; }

        public string NotificationTypeName => GetDisplayName(NotificationType);

        // Propiedad para obtener el valor del enum NotificationType
        public Enums.NotificationType NotificationTypeEnum
        {
            get
            {
                return Enum.TryParse(NotificationType, out Enums.NotificationType parsedEnum)
                    ? parsedEnum
                    : Enums.NotificationType.Notification; // Valor predeterminado
            }
        }


        // Función para obtener el DisplayName de TicketsStatus
        private string GetDisplayName(string NotificationType)
        {
            if (Enum.TryParse(NotificationType, out NotificationType parsedNotificationType))
            {
                return parsedNotificationType.GetDisplayName();
            }
            return string.Empty; // Devuelve vacío si no se puede obtener el nombre
        }

        public DateTime DateCreated { get; set; }
    }


}
