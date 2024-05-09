using MediatR;
using CRUD.API.Models.DTOs;

namespace CRUD.API.Handler.TeacherHandler
{
  public class UpdateTeacherCommand : IRequest<TeacherDTO>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
  }
}
