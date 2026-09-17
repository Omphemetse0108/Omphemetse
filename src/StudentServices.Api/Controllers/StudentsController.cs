using Microsoft.AspNetCore.Mvc;

namespace StudentServices.Api.Controllers;

public record Student(int Id, string FirstName, string LastName, string Programme);

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> _students = new()
    {
        new Student(1, "Thabo",  "Mokoena", "BSc Computer Science"),
        new Student(2, "Lerato", "Dlamini", "BCom Information Systems"),
        new Student(3, "Sipho",  "Nkosi",   "BSc Information Technology")
    };

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll() => Ok(_students);

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        return student is null ? NotFound() : Ok(student);
    }
}