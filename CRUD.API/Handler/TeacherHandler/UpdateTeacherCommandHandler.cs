using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRUD.API.Services;
using CRUD.API.Models.DTOs;
using FluentValidation;

namespace CRUD.API.Handler.TeacherHandler
{
  public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, TeacherDTO>
  {
    private readonly ITeacherService _teacherService;
    private readonly IValidator<TeacherDTO> _teacherValidator;

    public UpdateTeacherCommandHandler(ITeacherService teacherService, IValidator<TeacherDTO> teacherValidator)
    {
      _teacherService = teacherService;
      _teacherValidator = teacherValidator;
    }

    public async Task<TeacherDTO> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
      var teacherDto = new TeacherDTO
      {
        Id = request.Id,
        Name = request.Name,
        Email = request.Email,
        Subject = request.Subject
      };

      // Validation
      var validationResult = await _teacherValidator.ValidateAsync(teacherDto);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      // Updating the teacher
      await _teacherService.UpdateTeacherAsync(request.Id, teacherDto);
      return teacherDto;
    }
  }
}
