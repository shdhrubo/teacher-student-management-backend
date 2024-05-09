using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Services
{
  public class StudentService : IStudentService
  {
    private readonly IGenericRepository<Student> _studentRepository;

    public StudentService(IGenericRepository<Student> studentRepository)
    {
      _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
    {
      var students = await _studentRepository.GetAllAsync();
      return students.Select(student => new StudentDTO
      {
        Id = student.Id,
        Name = student.Name,
        Email = student.Email,
        TeacherId = student.TeacherId
      });
    }

    public async Task<StudentDTO> GetStudentByIdAsync(int id)
    {
      var student = await _studentRepository.GetByIdAsync(id);
      if (student == null)
        return null;

      return new StudentDTO
      {
        Id = student.Id,
        Name = student.Name,
        Email = student.Email,
        TeacherId = student.TeacherId
      };
    }

    public async Task<StudentDTO> CreateStudentAsync(StudentDTO studentDto)
    {
      var student = new Student
      {
        Name = studentDto.Name,
        Email = studentDto.Email,
        TeacherId = studentDto.TeacherId
      };

      await _studentRepository.AddAsync(student);
      studentDto.Id = student.Id;
      return studentDto;
    }

    public async Task UpdateStudentAsync(int id, StudentDTO studentDto)
    {
      var existingStudent = await _studentRepository.GetByIdAsync(id);
      if (existingStudent == null)
        return;

      existingStudent.Name = studentDto.Name;
      existingStudent.Email = studentDto.Email;
      existingStudent.TeacherId = studentDto.TeacherId;

      await _studentRepository.UpdateAsync(existingStudent);
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
      var existingStudent = await _studentRepository.GetByIdAsync(id);
      if (existingStudent == null)
        return false;

      await _studentRepository.DeleteAsync(existingStudent);
      return true;
    }
  }
}
