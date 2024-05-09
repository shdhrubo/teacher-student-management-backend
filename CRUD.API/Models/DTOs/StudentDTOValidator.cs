using CRUD.API.Models.Domains;
using FluentValidation;

namespace CRUD.API.Models.DTOs
{
  public class StudentDTOValidator : AbstractValidator<StudentDTO>
  {
    public StudentDTOValidator()
    {
      RuleFor(student => student.Name).NotEmpty().WithMessage("Name is required");
      RuleFor(student => student.Email).NotEmpty().WithMessage("Email address is required");
      RuleFor(student => student.TeacherId).NotEmpty().WithMessage("TeacherId is required");
    }
  }
}
