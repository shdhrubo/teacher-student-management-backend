using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;
using MediatR;

namespace CRUD.API.Handler.TeacherHandler
{
  public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<TeacherDTO>>
  {
    private readonly ITeacherService _teacherService;

    public GetAllTeacherQueryHandler(ITeacherService teacherService)
    {
      _teacherService = teacherService;
    }

    public async Task<IEnumerable<TeacherDTO>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
    {
      return await _teacherService.GetAllTeachersAsync();
    }
  }
}
