using AutoMapper;
using IRIS.Conecta.Application.Contracts.Persistence.Tickets;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsQuery;
using IRIS.Conecta.Application.MappingProfiles;
using IRIS.Conecta.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.Conecta.Application.UnitTests.Features.Tickets.Queries
{
    public class GetTicketsQueryHandlerTests
    {
        private readonly Mock<ITicketsRepository> _ticketsRepositoryMock;
        private IMapper _mapper;

        public GetTicketsQueryHandlerTests()
        {
            _ticketsRepositoryMock = MockTicketRepository.GetTicketsMockTicketRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TicketsProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetTicketsTest()
        {
            var handler = new GetTicketsQueryHandler(_mapper, _ticketsRepositoryMock.Object);

            var result = await handler.Handle(new GetTicketsQuery(), CancellationToken.None);


            result.ShouldBeOfType<List<TicketsListDto>>();
            result.Count.ShouldBe(3);

        }

    }
}
