using IRIS.Conecta.Application.Features.RequestTypes.Commands.CreateRequestType;
using IRIS.Conecta.Application.Features.RequestTypes.Commands.DeleteRequestType;
using IRIS.Conecta.Application.Features.RequestTypes.Commands.UpdateRequestType;
using IRIS.Conecta.Application.Features.RequestTypes.Dtos;
using IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypeById;
using IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<RequestTypesListDto>>> Get()
        {
            var requestTypes = await _mediator.Send(new GetRequestTypesListsRequest());
            return Ok(requestTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RequestTypesListDto>> Get(int id)
        {
            var requestType = await _mediator.Send(new GetRequestTypeByIdQuery { Id = id });
            return Ok(requestType);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateRequestTypeCommand requestTypeCommand)
        {
            var response = await _mediator.Send(requestTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateRequestTypeCommand requestTypeCommand)
        {
            await _mediator.Send(requestTypeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteRequestTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
