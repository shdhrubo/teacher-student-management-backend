using CRUD.API.Models.DTOs;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class GetStudentByIdQuery:IRequest<StudentDTO>
  {
    public int Id { get; }

    public GetStudentByIdQuery(int id)
    {
      Id = id;
    }
  }
}
