using MediatR;

namespace CRUD.API.Handler.TeacherHandler
{
  public class DeleteTeacherCommand : IRequest<Unit>
  {
    public int Id { get; set; }

    public DeleteTeacherCommand(int id)
    {
      Id = id;
    }
  }
}
