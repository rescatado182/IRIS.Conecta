using IRIS.Conecta.Application.Features.Departments.Commands.CreateDepartments;
using IRIS.Conecta.Application.Features.Departments.DTOs;
using IRIS.Conecta.Application.Features.Departments.Queries.GetDepartmentsLists;
using IRIS.Conecta.Application.Features.Faculties.Commands.CreateFaculty;
using IRIS.Conecta.Application.Features.Faculties.Commands.DeleteFaculty;
using IRIS.Conecta.Application.Features.Faculties.Commands.UpdateFaculty;
using IRIS.Conecta.Application.Features.RequestTypes.DTOs.RequestTypes;
using IRIS.Conecta.Application.Features.RequestTypes.Queries.GetRequestTypesLists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentsDto>>> Get()
        {
            var departments = await _mediator.Send(new GetDepartmentsListsRequest());
            return Ok(departments);
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
        public async Task<ActionResult> Put(UpdateFacultyCommand facultyCommand)
        {
            await _mediator.Send(facultyCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteFacultyCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
