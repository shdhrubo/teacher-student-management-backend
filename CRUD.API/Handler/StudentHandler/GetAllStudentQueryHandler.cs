using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;
using MediatR;

namespace CRUD.API.Handler.StudentHandler
{
  public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<StudentDTO>>
  {
    private readonly IStudentService _studentService;

    public GetAllStudentQueryHandler(IStudentService studentService)
    {
      _studentService = studentService;
    }

    public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
      return await _studentService.GetAllStudentsAsync();
    }
  }
}
