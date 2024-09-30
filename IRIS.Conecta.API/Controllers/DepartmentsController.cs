using IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartment;
using IRIS.Conecta.Application.Features.Departments.Commands.DeleteDepartment;
using IRIS.Conecta.Application.Features.Departments.Commands.UpdateDepartment;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentById;
using IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {
            var departments = await _mediator.Send(new GetDepartmentsListsRequest());
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var department = await _mediator.Send(new GetDepartmentByIdQuery { Id = id });
            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateDepartmentCommand departmentCommand)
        {
            var response = await _mediator.Send(departmentCommand);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateDepartmentCommand departmentCommand)
        {
            await _mediator.Send(departmentCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDepartmentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
