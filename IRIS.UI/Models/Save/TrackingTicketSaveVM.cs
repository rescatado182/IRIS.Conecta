namespace IRIS.UI.Models.Save
{
    public class TrackingTicketSaveVM
    {
        public int Id { get; set; }

        public string TicketId { get; set; }

        public enum TrackingType
        {
            Notification = 1,
            ChangeStatus = 2,
            Escalate = 3
        }

        public string UserTrackingId { get; set; } // Quien hizo el comentario, Si es cambio de estado automatico puede ir vacio

        public string Description { get; set; } //que comentario hizo

        public DateTime DateCreated { get; set; } //fecha y hora del comentario
    }
}
