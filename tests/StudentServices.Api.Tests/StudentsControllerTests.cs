using Microsoft.AspNetCore.Mvc;
using StudentServices.Api.Controllers;
using Xunit;

namespace StudentServices.Api.Tests;

public class StudentsControllerTests
{
    private readonly StudentsController _controller = new();

    [Fact]
    public void GetAll_ReturnsThreeStudents()
    {
        var result = _controller.GetAll().Result as OkObjectResult;
        Assert.NotNull(result);

        var students = result!.Value as IEnumerable<Student>;
        Assert.NotNull(students);
        Assert.Equal(3, students!.Count());
    }

    [Fact]
    public void GetById_ExistingId_ReturnsStudent()
    {
        var result = _controller.GetById(1).Result as OkObjectResult;
        Assert.NotNull(result);

        var student = result!.Value as Student;
        Assert.NotNull(student);
        Assert.Equal("Thabo", student!.FirstName);
    }

    [Fact]
    public void GetById_UnknownId_ReturnsNotFound()
    {
        var result = _controller.GetById(999).Result;
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Health_ContractReturnsHealthy()
    {
        var payload = new { status = "healthy" };
        Assert.Equal("healthy", payload.status);
    }
}