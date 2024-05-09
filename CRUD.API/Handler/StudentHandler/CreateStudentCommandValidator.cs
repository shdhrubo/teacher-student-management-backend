using FluentValidation;

namespace CRUD.API.Handler.StudentHandler
{
  public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
  {
    public CreateStudentCommandValidator()
    {
      RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Name is required.");

      RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email is required.");

      RuleFor(x => x.TeacherId)
          .NotEmpty().WithMessage("TeacherId is required.");
    }
  }
}
