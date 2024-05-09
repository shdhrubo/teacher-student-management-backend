using CRUD.API.Models.Domains;
using FluentValidation;

namespace CRUD.API.Models.DTOs
{
  public class TeacherDTOValidator : AbstractValidator<TeacherDTO>
  {
    public TeacherDTOValidator()
    {
      RuleFor(teacher => teacher.Name).NotEmpty().WithMessage("Name is required");
      RuleFor(teacher => teacher.Email).NotEmpty().WithMessage("Email is required");
      RuleFor(teacher => teacher.Subject).NotEmpty().WithMessage("Subject is required");
    }
  }
}
