using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class DeleteStudentCommand:IRequest<Unit>
  {
    public int Id { get; set; }

    public DeleteStudentCommand(int id)
    {
      Id = id;
    }
  }
}
