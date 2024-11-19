using IRIS.Conecta.Application.Features.Notifications.Commands.CreateNotification;
using IRIS.Conecta.Application.Features.Notifications.Dtos;
using IRIS.Conecta.Application.Features.Notifications.Queries.GetNotificationsByTicketId;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsListByUserId;
using IRIS.Conecta.Domain.Entities.Tickets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers.Tickets
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotificationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketsListDto>>> Get()
        {
            var tickets = await mediator.Send(new GetTicketsListRequest());
            return Ok(tickets);
        }

        [HttpGet("GetNotificationsByTicketId/{ticketId}")]
        public async Task<ActionResult<List<NotificationsDto>>> GetNotificationsByTicketId(int ticketId)
        {
            var notifications = await mediator.Send(new GetNotificationsByTicketIdRequest()
            {
                TicketId = ticketId
            });
            return Ok(notifications);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateNotificationCommand createNotification)
        {
            var response = await mediator.Send(createNotification);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
    }
}
