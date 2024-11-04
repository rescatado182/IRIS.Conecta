using IRIS.Conecta.Application.Features.PersonalData.Commands.CreatePersonalData;
using IRIS.Conecta.Application.Features.PersonalData.Commands.UpdatePersonalData;
using IRIS.Conecta.Application.Features.PersonalData.Dtos;
using IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataById;
using IRIS.Conecta.Application.Features.PersonalData.Queries.GetPersonalDataList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonalDataListDto>>> Get()
        {
            var data = await _mediator.Send( new GetPersonalDataListRequest() );
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalDataDto>> Get(int id)
        {
            var ticket = await _mediator.Send(new GetPersonalDataByIdRequest { Id = id });
            return Ok(ticket);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreatePersonalDataCommand createPersonalData)
        {
            var response = await _mediator.Send(createPersonalData);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdatePersonalDataCommand updatePersonalData)
        {
            await _mediator.Send(updatePersonalData);
            return NoContent();
        }
    }
}
