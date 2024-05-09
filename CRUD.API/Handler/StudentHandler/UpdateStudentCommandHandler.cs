using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRUD.API.Services;
using CRUD.API.Models.DTOs;
using FluentValidation;

namespace CRUD.API.Handler.StudentHandler
{
  public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentDTO>
  {
    private readonly IStudentService _studentService;
    private readonly IValidator<StudentDTO> _studentValidator;

    public UpdateStudentCommandHandler(IStudentService studentService, IValidator<StudentDTO> studentValidator)
    {
      _studentService = studentService;
      _studentValidator = studentValidator;
    }

    public async Task<StudentDTO> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
      var studentDto = new StudentDTO
      {
        Id = request.Id,
        Name = request.Name,
        Email = request.Email,
        TeacherId = request.TeacherId
      };

      // Validation
      var validationResult = await _studentValidator.ValidateAsync(studentDto);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      // Updating the student
      await _studentService.UpdateStudentAsync(request.Id, studentDto);
      return studentDto;
    }
  }
}
