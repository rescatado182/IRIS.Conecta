using IRIS.Conecta.Domain.Enums;

namespace IRIS.Conecta.Application.Features.Tickets.Dtos
{
    public class TicketBasicChangesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketsStatus Status { get; set; }
        public int RequestTypeId { get; set; }
        public string UserId { get; set; }        
        public int PersonalDataId { get; set; }
        public int AcademicDataId { get; set; }
    }
}
