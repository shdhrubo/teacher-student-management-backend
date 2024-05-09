using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;

namespace CRUD.API.Services
{
  public interface IStudentService
  {
    Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
    Task<StudentDTO> GetStudentByIdAsync(int id);
    Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto);
    Task UpdateStudentAsync(int id, StudentDTO studentDto);
    Task<bool> DeleteStudentAsync(int id);
  }
}
