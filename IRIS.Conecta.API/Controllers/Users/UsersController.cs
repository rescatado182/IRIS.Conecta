using IRIS.Conecta.Application.Features.Tickets.Dtos;
using IRIS.Conecta.Application.Features.Users.GetStudentById;
using IRIS.Conecta.Application.Features.Users.Queries.Managers.GetManagers;
using IRIS.Conecta.Application.Features.Users.Queries.Students.GetStudents;
using IRIS.Conecta.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRIS.Conecta.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentsRequest());
            return Ok(students);
        }

        [HttpGet("GetManagers")]
        public async Task<ActionResult<List<Student>>> GetManagers()
        {
            var managers = await _mediator.Send(new GetManagersRequest());
            return Ok(managers);
        }

        [HttpGet("GetUserByUserId/{userId}")]
        public async Task<ActionResult<Student>> Get(string userId)
        {
            var student = await _mediator.Send(new GetUserByIdRequest { UserId = userId });
            return Ok(student);
        }
    }
}
