namespace Infrastructure.Services;
using Infrastructure.Context;
using Domain.Entiti;
using Microsoft.EntityFrameworkCore;

public class CourseService
{
    private readonly DataContext dataContext;

    public CourseService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Course>> GetCourses()
    {
        return await dataContext.Courses.ToListAsync();
    }
    public async Task<Course> GetById(int id)
    {
        return await dataContext.Courses.FindAsync(id);
    }
    public async Task<Course> Update(Course course)
    {
        var find = await dataContext.Courses.FindAsync(course.Id);
        find.ImageName = course.ImageName;
        find.Fee = course.Fee;
        find.SubTitle = course.SubTitle;
        find.Title = course.Title;
        await dataContext.SaveChangesAsync();
        return course;
    }
    public async Task<bool> Delete(int id)
    {
        var find = await dataContext.Courses.FindAsync(id);
        dataContext.Courses.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
    public async Task<Course> AddCourse(Course course)
    {
        await dataContext.Courses.AddAsync(course);
        await dataContext.SaveChangesAsync();
        return course;
    }
}