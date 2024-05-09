using CRUD.API.Controllers;
using CRUD.API.Handler.StudentHandler;
using CRUD.API.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CRUD.API.Tests
{
  public class StudentsControllerTests
  {
    [Fact]
    public async Task CreateStudent_ReturnsCreatedAtAction()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      var controller = new StudentsController(mockMediator.Object);
      var command = new CreateStudentCommand();

      var expectedStudentDto = new StudentDTO { Id = 1 };

      //  MockMediator 
      mockMediator.Setup(m => m.Send(command, CancellationToken.None))
          .ReturnsAsync(expectedStudentDto);

      // Act
      var result = await controller.CreateStudent(command);

      // Assert
      var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
      Assert.Equal(nameof(controller.GetStudent), createdAtActionResult.ActionName);
      Assert.Equal(expectedStudentDto.Id, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task GetAllStudents_ReturnsOkObjectResult()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      var controller = new StudentsController(mockMediator.Object);
      var query = new GetAllStudentQuery();
      var students = new List<StudentDTO> { new StudentDTO { Id = 1 } };

      mockMediator.Setup(m => m.Send(query, CancellationToken.None)).ReturnsAsync(students);

      // Act
      var result = await controller.GetAllStudents() as OkObjectResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<OkObjectResult>(result);
      Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task GetStudent_ReturnsOkObjectResult()
    {
      // Arrange
      var studentId = 1;
      var expectedStudentDto = new StudentDTO { Id = studentId };

      var mockMediator = new Mock<IMediator>();
      mockMediator.Setup(m => m.Send(It.IsAny<GetStudentByIdQuery>(), CancellationToken.None))
                  .ReturnsAsync(expectedStudentDto);

      var controller = new StudentsController(mockMediator.Object);

      // Act
      var actionResult = await controller.GetStudent(studentId);

      // Assert
      var okObjectResult = Assert.IsType<OkObjectResult>(actionResult); 
      Assert.NotNull(okObjectResult); 

      Assert.Equal(200, okObjectResult.StatusCode); 

      var studentDto = Assert.IsType<StudentDTO>(okObjectResult.Value); 
      Assert.Equal(expectedStudentDto.Id, studentDto.Id); 
    }


    [Fact]
    public async Task UpdateStudent_ReturnsNoContentResult()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      var controller = new StudentsController(mockMediator.Object);
      var command = new UpdateStudentCommand { Id = 1 };

      // Act
      var result = await controller.UpdateStudent(1, command) as NoContentResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<NoContentResult>(result);
      Assert.Equal(204, result.StatusCode);
    }

    [Fact]
    public async Task DeleteStudent_ReturnsNoContentResult()
    {
      // Arrange
      var mockMediator = new Mock<IMediator>();
      var controller = new StudentsController(mockMediator.Object);

      // Act
      var result = await controller.DeleteStudent(1) as NoContentResult;

      // Assert
      Assert.NotNull(result);
      Assert.IsType<NoContentResult>(result);
      Assert.Equal(204, result.StatusCode);
    }
  }
}
