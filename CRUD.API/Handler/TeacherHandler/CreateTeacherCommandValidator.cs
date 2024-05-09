using FluentValidation;
using CRUD.API.Handler.TeacherHandler;

namespace CRUD.API.Validators
{
  public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
  {
    public CreateTeacherCommandValidator()
    {
      RuleFor(teacher => teacher.Name).NotEmpty().WithMessage("Name is required");
      RuleFor(teacher => teacher.Email).NotEmpty().WithMessage("Email is required");
      RuleFor(teacher => teacher.Subject).NotEmpty().WithMessage("Subject is required");
    }
  }
}
