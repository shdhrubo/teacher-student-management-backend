using CRUD.API.Handler.StudentHandler;
using CRUD.API.Models.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
    {
      var studentDto = await _mediator.Send(command);
      return CreatedAtAction(nameof(GetStudent), new { id = studentDto.Id }, studentDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
      var query = new GetAllStudentQuery();
      var students = await _mediator.Send(query);
      return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
      var query = new GetStudentByIdQuery(id);
      var studentDto = await _mediator.Send(query);

      if (studentDto == null)
      {
        return NotFound();
      }

      return Ok(studentDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand command)
    {
      if (id != command.Id)
      {
        return BadRequest();
      }

      await _mediator.Send(command);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
      var command = new DeleteStudentCommand(id);
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
