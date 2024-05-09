using Autofac;
using CRUD.API.Controllers;
using CRUD.API.Handler.TeacherHandler;
using CRUD.API.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace CRUD.API.Tests
{
  public class TeachersControllerTests
  {
    //[Fact]
    //public async Task CreateTeacher_ReturnsCreatedAtAction()
    //{
    //  // Arrange
    //  var mockMediator = new Mock<IMediator>();
    //  var controller = new TeachersController(mockMediator.Object);
    //  var command = new CreateTeacherCommand();

    //  var expectedTeacherDto = new TeacherDTO { Id = 1 };

    //  // MockMediator 
    //  mockMediator.Setup(m => m.Send(command, CancellationToken.None))
    //      .ReturnsAsync(expectedTeacherDto);

    //  // Act
    //  var result = await controller.CreateTeacher(command);

    //  // Assert
    //  var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
    //  Assert.Equal(nameof(controller.GetTeacher), createdAtActionResult.ActionName);
    //  Assert.Equal(expectedTeacherDto.Id, createdAtActionResult.RouteValues["id"]);
    //}

    [Fact]
    public async Task CreateTeacher_ReturnsCreatedAtAction()
    {
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeachersController>().InstancePerDependency();

      // Register IMediator mock
      var mockMediator = new Mock<IMediator>();
      var command = new CreateTeacherCommand();
      var expectedTeacherDto = new TeacherDTO { Id = 1 };

      // MockMediator 
      mockMediator.Setup(m => m.Send(command, CancellationToken.None))
          .ReturnsAsync(expectedTeacherDto);

      builder.RegisterInstance(mockMediator.Object).As<IMediator>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the controller from the IoC container
      var controller = container.Resolve<TeachersController>();

      // Act
      var result = await controller.CreateTeacher(command);

      // Assert
      var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
      Assert.Equal(nameof(controller.GetTeacher), createdAtActionResult.ActionName);
      Assert.Equal(expectedTeacherDto.Id, createdAtActionResult.RouteValues["id"]);
    }


    [Fact]
    public async Task GetAllTeachers_ReturnsOkObjectResult()
    {
      // Arrange
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeachersController>().InstancePerDependency();

      var mockMediator = new Mock<IMediator>();
      var query = new GetAllTeacherQuery();
      var teachers = new List<TeacherDTO> { new TeacherDTO { Id = 1 } };

      mockMediator.Setup(m => m.Send(query, CancellationToken.None)).ReturnsAsync(teachers);

      builder.RegisterInstance(mockMediator.Object).As<IMediator>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the controller from the IoC container
      var controller = container.Resolve<TeachersController>();

      // Act
      var result = await controller.GetAllTeachers() as OkObjectResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<OkObjectResult>(result);
      Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task GetTeacher_ReturnsOkObjectResult()
    {
      // Arrange
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeachersController>().InstancePerDependency();

      var mockMediator = new Mock<IMediator>();
      var teacherId = 1;
      var expectedTeacherDto = new TeacherDTO { Id = teacherId };

      mockMediator.Setup(m => m.Send(It.IsAny<GetTeacherByIdQuery>(), CancellationToken.None))
                  .ReturnsAsync(expectedTeacherDto);

      builder.RegisterInstance(mockMediator.Object).As<IMediator>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the controller from the IoC container
      var controller = container.Resolve<TeachersController>();

      // Act
      var actionResult = await controller.GetTeacher(teacherId);

      // Assert
      Assert.NotNull(actionResult);

      var okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
      Assert.Equal(200, okObjectResult.StatusCode);

      var teacherDto = Assert.IsType<TeacherDTO>(okObjectResult.Value);
      Assert.Equal(expectedTeacherDto.Id, teacherDto.Id);
    }

    [Fact]
    public async Task UpdateTeacher_ReturnsNoContentResult()
    {
      // Arrange
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeachersController>().InstancePerDependency();

      var mockMediator = new Mock<IMediator>();
      var command = new UpdateTeacherCommand { Id = 1 };

      builder.RegisterInstance(mockMediator.Object).As<IMediator>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the controller from the IoC container
      var controller = container.Resolve<TeachersController>();

      // Act
      var result = await controller.UpdateTeacher(1, command) as NoContentResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<NoContentResult>(result);
      Assert.Equal(204, result.StatusCode);
    }

    [Fact]
    public async Task DeleteTeacher_ReturnsNoContentResult()
    {
      // Arrange
      var builder = new ContainerBuilder();

      // Register dependencies
      builder.RegisterType<TeachersController>().InstancePerDependency();

      var mockMediator = new Mock<IMediator>();

      builder.RegisterInstance(mockMediator.Object).As<IMediator>();

      // Build the container
      var container = builder.Build();

      // Resolve instance of the controller from the IoC container
      var controller = container.Resolve<TeachersController>();

      // Act
      var result = await controller.DeleteTeacher(1) as NoContentResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<NoContentResult>(result);
      Assert.Equal(204, result.StatusCode);
    }
  }
}
