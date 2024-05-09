using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;

namespace CRUD.API.Handler.StudentHandler
{
  public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDTO>
  {
    private readonly IStudentService _studentService;

    public GetStudentByIdQueryHandler(IStudentService studentService)
    {
      _studentService = studentService;
    }

    public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
      var studentId = request.Id;
      var studentDto = await _studentService.GetStudentByIdAsync(studentId);
      return studentDto;
    }
  }
}
