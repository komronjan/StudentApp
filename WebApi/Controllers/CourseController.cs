using Domain.Entiti;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController
{
    private readonly CourseService courseService;

    public CourseController(CourseService _courseService)
    {
        courseService = _courseService;
    }
    [HttpGet("Get")]
    public async Task<List<Course>> GetCourses()
    {
        return await courseService.GetCourses();
    }
    [HttpGet("GetById")]
    public async Task<Course> GetGroupById(int id)
    {
        return await courseService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<Course> add([FromForm] Course course)
    {
        return await courseService.AddCourse(course);
    }
    [HttpPut("Update")]
    public async Task<Course> Update([FromForm] Course course)
    {
        return await courseService.Update(course);
    }
    [HttpDelete("Delete")]
    public async Task<bool> Delete(int id)
    {
        return await courseService.Delete(id);
    }


}
