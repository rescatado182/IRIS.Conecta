using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Dtos
{
    public class TicketsListDto
    {
        public int Id { get; set; }
        public string RequestTypeId { get; set; }
        public string Title { get; set; }
        public string AgreementName { get; set; }
        public string EventName { get; set; }
        public TicketsStatus Status { get; set; }
        public DateOnly createDate { get; set; }
    }
}
