namespace IRIS.UI.Models.Save
{
    public class ResponseTicketsVM
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ManagerRespondeId { get; set; }
        public string MessageResponse { get; set; }
        
    }
}
