using CRUD.API.Models.DTOs;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class UpdateStudentCommand:IRequest<StudentDTO>
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TeacherId { get; set; }
  }
}
