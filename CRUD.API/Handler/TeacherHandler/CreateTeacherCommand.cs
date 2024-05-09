using CRUD.API.Models.DTOs;
using MediatR;

namespace CRUD.API.Handler.TeacherHandler
{
  public class CreateTeacherCommand :IRequest<TeacherDTO>
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
  }
}
