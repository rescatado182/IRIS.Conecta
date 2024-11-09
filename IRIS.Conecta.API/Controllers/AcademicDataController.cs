using IRIS.Conecta.Application.Features.AcademicData.Commands.CreateAcademicData;
using IRIS.Conecta.Application.Features.AcademicData.Commands.UpdateAcademicData;
using IRIS.Conecta.Application.Features.AcademicData.Dtos;
using IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataById;
using IRIS.Conecta.Application.Features.AcademicData.Queries.GetAcademicDataList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AcademicDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AcademicDataListDto>>> Get()
        {
            var data = await _mediator.Send( new GetAcademicDataListRequest() );
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicDataDto>> Get(int id)
        {
            var ticket = await _mediator.Send(new GetAcademicDataByIdRequest { Id = id });
            return Ok(ticket);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Post(CreateAcademicDataCommand createAcademicData)
        {
            var response = await _mediator.Send(createAcademicData);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateAcademicDataCommand updateAcademicData)
        {
            await _mediator.Send(updateAcademicData);
            return NoContent();
        }
    }
}
