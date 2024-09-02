using IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes;
using IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacultiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestTypesDTO>>> Get()
        {
            var requestTypes = await _mediator.Send(new GetRequestTypesListsRequest());
            return Ok(requestTypes);
        }
    }
}
