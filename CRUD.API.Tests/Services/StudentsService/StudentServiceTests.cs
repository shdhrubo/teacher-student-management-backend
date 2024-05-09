using CRUD.API.Models.Domains;
using CRUD.API.Models.DTOs;
using CRUD.API.Repositories;
using CRUD.API.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CRUD.API.Tests.Services
{
  public class StudentServiceTests
  {
    
    [Fact]
    public async Task GetStudentByIdAsync_ReturnsStudentDTOIfExists()
    {
      // Arrange
      var studentId = 1;
      var student = new Student { Id = studentId, Name = "Akash", Email = "akash@gmail.com", TeacherId = 1 };

      var mockRepository = new Mock<IGenericRepository<Student>>();
      mockRepository.Setup(repo => repo.GetByIdAsync(studentId)).ReturnsAsync(student);

      var service = new StudentService(mockRepository.Object);

      // Act
      var result = await service.GetStudentByIdAsync(studentId);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<StudentDTO>(result);
      Assert.Equal(student.Id, result.Id);
    }

    [Fact]
    public async Task CreateStudentAsync_CreatesStudentAndReturnsStudentDTO()
    {
      // Arrange
      var studentDto = new StudentDTO { Name = "Akash", Email = "akash@gmail.com", TeacherId = 1 };

      var mockRepository = new Mock<IGenericRepository<Student>>();
      mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Student>())).Returns(Task.CompletedTask);

      var service = new StudentService(mockRepository.Object);

      // Act
      var result = await service.CreateStudentAsync(studentDto);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<StudentDTO>(result);
      Assert.NotNull(result.Id);
      Assert.Equal(studentDto.Name, result.Name);
      Assert.Equal(studentDto.Email, result.Email);
      Assert.Equal(studentDto.TeacherId, result.TeacherId);
    }

    [Fact]
    public async Task UpdateStudentAsync_UpdatesStudent()
    {
      // Arrange
      var studentId = 1;
      var studentDto = new StudentDTO { Id = studentId, Name = "Akash", Email = "akash@gmail.com", TeacherId = 1 };

      var mockRepository = new Mock<IGenericRepository<Student>>();
      mockRepository.Setup(repo => repo.GetByIdAsync(studentId)).ReturnsAsync(new Student());

      var service = new StudentService(mockRepository.Object);

      // Act
      await service.UpdateStudentAsync(studentId, studentDto);

      // Assert
      mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public async Task DeleteStudentAsync_DeletesStudent()
    {
      // Arrange
      var studentId = 1;

      var mockRepository = new Mock<IGenericRepository<Student>>();
      mockRepository.Setup(repo => repo.GetByIdAsync(studentId)).ReturnsAsync(new Student());

      var service = new StudentService(mockRepository.Object);

      // Act
      var result = await service.DeleteStudentAsync(studentId);

      // Assert
      Assert.True(result);
      mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Student>()), Times.Once);
    }
  }
}
