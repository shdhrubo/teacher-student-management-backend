using System;
using System.Threading;
using System.Threading.Tasks;
using CRUD.API.Handler.StudentHandler;
using CRUD.API.Services;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
  {
    private readonly IStudentService _studentService;

    public DeleteStudentCommandHandler(IStudentService studentService)
    {
      _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
    }

    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
      var deleted = await _studentService.DeleteStudentAsync(request.Id);
      if (!deleted)
      {
        throw new Exception($"Student with ID {request.Id} not found.");
      }

      return Unit.Value;
    }
  }
}
