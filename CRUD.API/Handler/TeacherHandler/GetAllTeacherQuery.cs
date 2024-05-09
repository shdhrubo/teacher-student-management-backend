using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CRUD.API.Models.DTOs;
using CRUD.API.Services;

namespace CRUD.API.Handler.TeacherHandler
{
  public class GetAllTeacherQuery : IRequest<IEnumerable<TeacherDTO>>
  {
  }
}
