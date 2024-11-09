using IRIS.Conecta.Application.Features.Program.Commands.CreateProgram;
using IRIS.Conecta.Application.Features.Program.Commands.DeleteProgram;
using IRIS.Conecta.Application.Features.Program.Commands.UpdateProgram;
using IRIS.Conecta.Application.Features.Program.Dtos;
using IRIS.Conecta.Application.Features.Program.Queries.GetProgramById;
using IRIS.Conecta.Application.Features.Program.Queries.GetProgramsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProgramDto>>> Get()
        {
            var programs = await _mediator.Send(new GetProgramsListRequest());
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramDto>> Get(int id)
        {
            var program = await _mediator.Send(new GetProgramByIdQuery { Id = id });
            return Ok(program);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateProgramCommand createProgramCommand)
        {
            var response = await _mediator.Send(createProgramCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateProgramCommand updateProgramCommand)
        {
            await _mediator.Send(updateProgramCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProgramCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
