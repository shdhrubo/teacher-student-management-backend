using CRUD.API.Models.DTOs;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class GetAllStudentQuery:IRequest<IEnumerable<StudentDTO>>
  {
  }
}
