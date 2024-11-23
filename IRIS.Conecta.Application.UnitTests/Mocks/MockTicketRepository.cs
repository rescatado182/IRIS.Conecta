using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Domain.Entities.Tickets;
using IRIS.Conecta.Domain.Enums;
using Moq;

namespace IRIS.Conecta.Application.UnitTests.Mocks
{
    public class MockTicketRepository
    {
        public static Mock<ITicketsRepository> GetTicketsMockTicketRepository()
        {
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id              = 10,
                    Title           = "COP 16 - Cali, Colombia",
                    Status          = TicketsStatus.Closed,
                    RequestTypeId   = 1,
                    UserId          = "1001",
                    ManagerUserId   = "1002"
                },

                new Ticket
                {
                    Id              = 11,
                    Title           = "COP 29, Bakú, Azerbaijan",
                    Status          = TicketsStatus.InProcess,
                    RequestTypeId   = 1,
                    UserId          = "712b8bfa-bc1e-44c9-894f-6c65713c7551",
                    ManagerUserId   = "1002"
                },

                new Ticket
                {
                    Id              = 12,
                    Title           = "COP24 - New York, 2025",
                    Status          = TicketsStatus.Open,
                    RequestTypeId   = 1,
                    UserId          = "712b8bfa-bc1e-44c9-894f-6c65713c7551",
                    ManagerUserId   = "1003"
                }
            };

            var mockRepo = new Mock<ITicketsRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(tickets);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Ticket>()))
                .Returns((Ticket ticket) =>
                {
                    tickets.Add(ticket);
                    return Task.FromResult(ticket);
                });

            return mockRepo;


        }
    }
}
