using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;
using CRUD.API.Handler.TeacherHandler;
using FluentValidation;

namespace CRUD.API.Services
{
  public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, TeacherDTO>
  {
    private readonly IValidator<CreateTeacherCommand> _validator;
    private readonly ITeacherService _teacherService;

    public CreateTeacherCommandHandler(IValidator<CreateTeacherCommand> validator, ITeacherService teacherService)
    {
      _validator = validator;
      _teacherService = teacherService;
    }

    public async Task<TeacherDTO> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      var teacherDto = new TeacherDTO
      {
        Name = request.Name,
        Email = request.Email,
        Subject = request.Subject
      };

      return await _teacherService.CreateTeacherAsync(teacherDto);
    }
  }

}
