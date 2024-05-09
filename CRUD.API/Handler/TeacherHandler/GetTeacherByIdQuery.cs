using MediatR;
using CRUD.API.Models.DTOs;

namespace CRUD.API.Handler.TeacherHandler
{
  public class GetTeacherByIdQuery : IRequest<TeacherDTO>
  {
    public int Id { get; }

    public GetTeacherByIdQuery(int id)
    {
      Id = id;
    }
  }
}
