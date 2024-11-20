namespace IRIS.UI.Models.Save
{
    public class TicketSaveVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }
        public string UserId { get; set; }

        public string ManagerUserId { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
