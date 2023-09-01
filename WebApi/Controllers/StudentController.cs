using Domain.Entiti;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet("GetStudent")]
    public async Task<List<Student>> GetStudent()
    {
        return await _studentService.GetStudents();
    }
    [HttpGet("GetById")]
    public async Task<Student> GetStudentById(int id)
    {
        return await _studentService.GetById(id);
    }
    [HttpDelete("DeleteStudent")]
    public async Task<bool> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }
    [HttpPost("AddStudent")]
    public async Task<Student> AddStudent([FromForm] Student students)
    {
        return await _studentService.CreateStudent(students);
    }
    [HttpPut("UpdateStudent")]
    public async Task<Student> UpdateStudentp([FromForm] Student students)
    {
        return await _studentService.UpdateStudent(students);
    }
}
