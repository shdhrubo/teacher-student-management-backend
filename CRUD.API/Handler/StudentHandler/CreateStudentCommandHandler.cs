using CRUD.API.Handler.TeacherHandler;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;
using FluentValidation;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,StudentDTO>
  {
    private readonly IValidator<CreateStudentCommand> _validator;
    private readonly IStudentService _studentService;

    public CreateStudentCommandHandler(IValidator<CreateStudentCommand> validator, IStudentService studentService)
    {
      _validator = validator;
      _studentService = studentService;
    }
    public async Task<StudentDTO> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      var studentDto = new StudentDTO
      {
        Name = request.Name,
        Email = request.Email,
        TeacherId=request.TeacherId,
      };

      return await _studentService.CreateStudentAsync(studentDto);
    }
  }
}

