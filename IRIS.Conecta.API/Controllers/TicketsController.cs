using IRIS.Conecta.Application.Features.Tickets.Commands.ChangeTicketStatus;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.CreateTicket;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicket;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByMovility;
using IRIS.Conecta.Application.Features.Tickets.Commands.MovilityCommands.UpdateTicketByRequirements;
using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketById;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsList;
using IRIS.Conecta.Application.Features.Tickets.Queries.GetTicketsListByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TicketsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TicketsListDto>>> Get()
        {
            var tickets = await this.mediator.Send( new GetTicketsListRequest() );
            return Ok(tickets);
        }

        [HttpGet("GetTicketsByUser/{userId}")]
        public async Task<ActionResult<List<TicketsListDto>>> GetTicketsByUser(string userId)
        {
            var tickets = await this.mediator.Send(new GetTicketsListByUserIdRequest()
            {
                UserId = userId
            });
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketByIdDto>> Get(int id)
        {
            var ticket = await this.mediator.Send(new GetTicketByIdRequest { Id = id });
            return Ok(ticket);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateTicketCommand createTicketCommand)
        {
            var response = await this.mediator.Send(createTicketCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut("updateTicket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]        
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateTicketCommand updateTicketCommand)
        {
            await this.mediator.Send(updateTicketCommand);
            return NoContent();
        }

        [HttpPut("updateTicketByMovility")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutByMovility(UpdateTicketByMovilityCommand updateTicketByMovility)
        {
            await this.mediator.Send(updateTicketByMovility);
            return NoContent();
        }

        [HttpPut("updateTicketByRequirements")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutByRequirements(UpdateTicketByRequirementsCommand updateTicketByRequirements)
        {
            await this.mediator.Send(updateTicketByRequirements);
            return NoContent();
        }

        [HttpPut]
        [Route("ChangeTicketStatus")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ChangeTicketStatus(ChangeTicketStatusCommand changeTicketStatusCommand)
        {
            await this.mediator.Send(changeTicketStatusCommand);
            return NoContent();
        }

    }
}
