namespace IRIS.UI.Models
{
    public class TrackingTicketVM
    {
        public int Id { get; set; }

        public string TicketId { get; set; }

        public enum TrackingType
        {
            Notification = 1,
            ChangeStatus = 2
        }

        public string UserTrackingId { get; set; } // Quien hizo el comentario, Si es cambio de estado automatico puede ir vacio

        public string UserTrackingName { get; set; } //nombre usuario

        public string Description { get; set; } //que comentario hizo

        public DateTime DateCreated { get; set; } //fecha y hora del comentario
    }
}
