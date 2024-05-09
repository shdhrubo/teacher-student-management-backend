using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;

namespace CRUD.API.Services
{
  public interface ITeacherService
  {
    Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync();
    Task<TeacherDTO> GetTeacherByIdAsync(int id);
    Task<TeacherDTO> CreateTeacherAsync(TeacherDTO teacherDto);
    Task UpdateTeacherAsync(int id, TeacherDTO teacherDto);
    Task<bool> DeleteTeacherAsync(int id);
  }
}
