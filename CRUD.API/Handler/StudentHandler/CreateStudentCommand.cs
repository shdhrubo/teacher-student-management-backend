using CRUD.API.Models.DTOs;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class CreateStudentCommand:IRequest<StudentDTO>
  {
    public string Name { get; set;}
    public string Email { get; set;}
    public int TeacherId { get; set; }
  }
}
