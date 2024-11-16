namespace IRIS.UI.Models
{
    public class RequirementsMovilitySaveVM
    {

        public int Id { get; set; }
        public TicketsStatus Status { get; set; }
        public DateOnly StartDateRequirement { get; set; }
        public DateOnly EndDateRequirement { get; set; }
        public double Total { get; set; }
        public string UserId { get; set; }
        public string ManagerUserId { get; set; }
        public List<EnumTicketRequirements> TicketRequirements { get; set; }

    }
}
