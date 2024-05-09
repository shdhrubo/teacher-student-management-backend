using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.API.Services
{
  public class TeacherService : ITeacherService
  {
    private readonly IGenericRepository<Teacher> _teacherRepository;

    public TeacherService(IGenericRepository<Teacher> teacherRepository)
    {
      _teacherRepository = teacherRepository;
    }

    public async Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync()
    {
      var teachers = await _teacherRepository.GetAllAsync();
      var teacherDtos = new List<TeacherDTO>();
      foreach (var teacher in teachers)
      {
        teacherDtos.Add(new TeacherDTO
        {
          Id = teacher.Id,
          Name = teacher.Name,
          Email = teacher.Email,
          Subject = teacher.Subject
        });
      }
      return teacherDtos;
    }

    public async Task<TeacherDTO> GetTeacherByIdAsync(int id)
    {
      var teacher = await _teacherRepository.GetByIdAsync(id);
      if (teacher == null)
        return null;

      return new TeacherDTO
      {
        Id = teacher.Id,
        Name = teacher.Name,
        Email = teacher.Email,
        Subject = teacher.Subject
      };
    }

    public async Task<TeacherDTO> CreateTeacherAsync(TeacherDTO teacherDto)
    {
      var teacher = new Teacher
      {
        Name = teacherDto.Name,
        Email = teacherDto.Email,
        Subject = teacherDto.Subject
      };

      await _teacherRepository.AddAsync(teacher);
      teacherDto.Id = teacher.Id; 
      return teacherDto;
    }

    public async Task UpdateTeacherAsync(int id, TeacherDTO teacherDto)
    {
      var existingTeacher = await _teacherRepository.GetByIdAsync(id);
      if (existingTeacher == null)
        return;

      existingTeacher.Name = teacherDto.Name;
      existingTeacher.Email = teacherDto.Email;
      existingTeacher.Subject = teacherDto.Subject;

      await _teacherRepository.UpdateAsync(existingTeacher);
    }

    public async Task<bool> DeleteTeacherAsync(int id)
    {
      var existingTeacher = await _teacherRepository.GetByIdAsync(id);
      if (existingTeacher == null)
        return false;

      await _teacherRepository.DeleteAsync(existingTeacher);
      return true;
    }
  }
}
