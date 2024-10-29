namespace IRIS.UI.Models
{
    public class TicketVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }


    }
}
