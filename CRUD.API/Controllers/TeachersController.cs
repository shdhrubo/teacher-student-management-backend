using CRUD.API.Handler.TeacherHandler;
using CRUD.API.Models.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CRUD.API.Controllers
{
 [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class TeachersController : ControllerBase
  {
    private readonly IMediator _mediator;
    public TeachersController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTeacher(CreateTeacherCommand command)
    {
     

      var teacherDto = await _mediator.Send(command);
      return CreatedAtAction(nameof(GetTeacher), new { id = teacherDto.Id }, teacherDto);
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllTeachers(int pageNumber = 1, int pageSize = 10)
    {
      var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
      Console.WriteLine(email);
      // Now you can proceed with your existing logic to get teachers
      var query = new GetAllTeacherQuery();
      var teachers = await _mediator.Send(query);
      teachers = teachers.OrderBy(t => t.Id);
      var totalTeachers = teachers.Count();
      var paginatedTeachers = teachers.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToList();
      return Ok(new { teachers = paginatedTeachers, totalTeachers });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
      var query = new GetTeacherByIdQuery(id);
      var teacherDto = await _mediator.Send(query);

      if (teacherDto == null)
      {
        return NotFound();
      }

      return Ok(teacherDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherCommand command)
    {
      if (id != command.Id)
      {
        return BadRequest();
      }

      await _mediator.Send(command);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
      var command = new DeleteTeacherCommand(id);
      await _mediator.Send(command);

      return NoContent();
    }
  }
}

//using Microsoft.AspNetCore.Mvc;
//using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Authorization;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Threading.Tasks;
//using CRUD.API.Handler.TeacherHandler;
//using MediatR;
//using System.Linq;

//namespace CRUD.API.Controllers
//{
//  [Authorize]
//  [Route("api/[controller]")]
//  [ApiController]
//  public class TeachersController : ControllerBase
//  {
//    private readonly IMediator _mediator;
//    private readonly string secretKey = "MExlfa09TyHvCI5fw9WdpquRsQ26FolEybO4Kzd8ai23A79r-nZdf9_ch0GUgZhz";

//    public TeachersController(IMediator mediator)
//    {
//      _mediator = mediator;
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateTeacher(CreateTeacherCommand command)
//    {
//      return await ValidateAndExecuteAction(async () =>
//      {
//        var teacherDto = await _mediator.Send(command);
//        return CreatedAtAction(nameof(GetTeacher), new { id = teacherDto.Id }, teacherDto);
//      });
//    }
//    [Authorize]
//    [HttpGet]
//    public async Task<IActionResult> GetAllTeachers(int pageNumber = 1, int pageSize = 10)
//    {
//      return await ValidateAndExecuteAction(async () =>
//      {
//        var query = new GetAllTeacherQuery();
//        var teachers = await _mediator.Send(query);
//        teachers = teachers.OrderBy(t => t.Id);
//        var totalTeachers = teachers.Count();
//        var paginatedTeachers = teachers.Skip((pageNumber - 1) * pageSize)
//                                       .Take(pageSize)
//                                       .ToList();
//        return Ok(new { teachers = paginatedTeachers, totalTeachers });
//      });
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetTeacher(int id)
//    {
//      return await ValidateAndExecuteAction(async () =>
//      {
//        var query = new GetTeacherByIdQuery(id);
//        var teacherDto = await _mediator.Send(query);

//        if (teacherDto == null)
//          return NotFound();

//        return Ok(teacherDto);
//      });
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherCommand command)
//    {
//      return await ValidateAndExecuteAction(async () =>
//      {
//        if (id != command.Id)
//          return BadRequest();

//        await _mediator.Send(command);

//        return NoContent();
//      });
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteTeacher(int id)
//    {
//      return await ValidateAndExecuteAction(async () =>
//      {
//        var command = new DeleteTeacherCommand(id);
//        await _mediator.Send(command);

//        return NoContent();
//      });
//    }

//    private async Task<IActionResult> ValidateAndExecuteAction(Func<Task<IActionResult>> action)
//    {
//      var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//      if (string.IsNullOrEmpty(token))
//        return Unauthorized();

//      var tokenHandler = new JwtSecurityTokenHandler();
//      var key = Encoding.ASCII.GetBytes(secretKey);

//      try
//      {
//        tokenHandler.ValidateToken(token, new TokenValidationParameters
//        {
//          ValidateIssuerSigningKey = true,
//          IssuerSigningKey = new SymmetricSecurityKey(key),
//          ValidateIssuer = false,
//          ValidateAudience = false,
//          RequireExpirationTime = true,
//          ValidateLifetime = true
//        }, out SecurityToken validatedToken);

//        // Token is valid, execute the action
//        return await action();
//      }
//      catch (Exception)
//      {
//        // Token validation failed
//        return Unauthorized();
//      }
//    }
//  }
//}
