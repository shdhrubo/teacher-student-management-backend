using Autofac;
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
  public class TeacherServiceTests
  {
    [Fact]
    public async Task GetAllTeachersAsync_ReturnsListOfTeacherDTOs()
    {
      // Arrange
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeacherService>().As<ITeacherService>();
      var mockRepository = new Mock<IGenericRepository<Teacher>>();
      var teachers = new List<Teacher>
            {
                new Teacher { Id = 1, Name = "Iftekhar", Email = "iftee@gmail.com", Subject = "Math" },
            };

      mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(teachers);
      builder.RegisterInstance(mockRepository.Object).As<IGenericRepository<Teacher>>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the service from the IoC container
      var service = container.Resolve<ITeacherService>();

      // Act
      var result = await service.GetAllTeachersAsync();

      // Assert
      Assert.NotNull(result);
      Assert.IsType<List<TeacherDTO>>(result);
      Assert.Equal(teachers.Count, result.Count());
    }

    [Fact]
    public async Task GetTeacherByIdAsync_ReturnsTeacherDTOIfExists()
    {
      // Arrange
      var teacherId = 1;
      var teacher = new Teacher { Id = teacherId, Name = "Akash Sen", Email = "akash@gmail.com", Subject = "Math" };

      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeacherService>().As<ITeacherService>();
      var mockRepository = new Mock<IGenericRepository<Teacher>>();

      mockRepository.Setup(repo => repo.GetByIdAsync(teacherId)).ReturnsAsync(teacher);
      builder.RegisterInstance(mockRepository.Object).As<IGenericRepository<Teacher>>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the service from the IoC container
      var service = container.Resolve<ITeacherService>();

      // Act
      var result = await service.GetTeacherByIdAsync(teacherId);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<TeacherDTO>(result);
      Assert.Equal(teacher.Id, result.Id);
    }

    [Fact]
    public async Task CreateTeacherAsync_CreatesTeacherAndReturnsTeacherDTO()
    {
      // Arrange
      var teacherDto = new TeacherDTO { Name = "Akash Sen", Email = "akash@gmail.com", Subject = "Math" };

      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeacherService>().As<ITeacherService>();
      var mockRepository = new Mock<IGenericRepository<Teacher>>();

      mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Teacher>())).Returns(Task.CompletedTask);
      builder.RegisterInstance(mockRepository.Object).As<IGenericRepository<Teacher>>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the service from the IoC container
      var service = container.Resolve<ITeacherService>();

      // Act
      var result = await service.CreateTeacherAsync(teacherDto);

      // Assert
      Assert.NotNull(result);
      Assert.IsType<TeacherDTO>(result);
      Assert.NotNull(result.Id);
      Assert.Equal(teacherDto.Name, result.Name);
      Assert.Equal(teacherDto.Email, result.Email);
      Assert.Equal(teacherDto.Subject, result.Subject);
    }

    [Fact]
    public async Task UpdateTeacherAsync_UpdatesTeacher()
    {
      // Arrange
      var teacherId = 1;
      var teacherDto = new TeacherDTO { Id = teacherId, Name = "Akash Sen", Email = "akash@gmail.com", Subject = "Math" };

      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeacherService>().As<ITeacherService>();
      var mockRepository = new Mock<IGenericRepository<Teacher>>();

      mockRepository.Setup(repo => repo.GetByIdAsync(teacherId)).ReturnsAsync(new Teacher());
      builder.RegisterInstance(mockRepository.Object).As<IGenericRepository<Teacher>>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the service from the IoC container
      var service = container.Resolve<ITeacherService>();

      // Act
      await service.UpdateTeacherAsync(teacherId, teacherDto);

      // Assert
      mockRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Teacher>()), Times.Once);
    }

    [Fact]
    public async Task DeleteTeacherAsync_DeletesTeacher()
    {
      // Arrange
      var teacherId = 1;

      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeacherService>().As<ITeacherService>();
      var mockRepository = new Mock<IGenericRepository<Teacher>>();

      mockRepository.Setup(repo => repo.GetByIdAsync(teacherId)).ReturnsAsync(new Teacher());
      builder.RegisterInstance(mockRepository.Object).As<IGenericRepository<Teacher>>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the service from the IoC container
      var service = container.Resolve<ITeacherService>();

      // Act
      var result = await service.DeleteTeacherAsync(teacherId);

      // Assert
      Assert.True(result);
      mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Teacher>()), Times.Once);
    }
  }
}
