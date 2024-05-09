using System;
using System.Threading;
using System.Threading.Tasks;
using CRUD.API.Handler.TeacherHandler;
using CRUD.API.Services;
using MediatR;
using CRUD.API;

namespace StudentTeacher_BackEnd_.Handler.TeacherHandler
{
  public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Unit>
  {
    private readonly ITeacherService _teacherService;

    public DeleteTeacherCommandHandler(ITeacherService teacherService)
    {
      _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
    }

    public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
      var deleted = await _teacherService.DeleteTeacherAsync(request.Id);
      if (!deleted)
      {
        throw new Exception($"Teacher with ID {request.Id} not found.");
      }

      return Unit.Value;
    }
  }
}
