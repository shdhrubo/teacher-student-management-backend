using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;

namespace CRUD.API.Handler.TeacherHandler
{
  public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDTO>
  {
    private readonly ITeacherService _teacherService;

    public GetTeacherByIdQueryHandler(ITeacherService teacherService)
    {
      _teacherService = teacherService;
    }

    public async Task<TeacherDTO> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
      var teacherId = request.Id;
      var teacherDto = await _teacherService.GetTeacherByIdAsync(teacherId);
      return teacherDto;
    }
  }
}
