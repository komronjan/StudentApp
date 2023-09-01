using Domain.Entiti;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService
{
    DataContext dataContext;
    public StudentService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Student>> GetStudents()
    {
        return await dataContext.Students.ToListAsync();
    }
    public async Task<Student> GetById(int id)
    {
        return await dataContext.Students.FindAsync(id);
    }
    public async Task<Student> CreateStudent(Student student)
    {
        student.BirthDate = DateTime.SpecifyKind(student.BirthDate, DateTimeKind.Utc);
        await dataContext.Students.AddAsync(student);
        await dataContext.SaveChangesAsync();
        return student;
    }
    public async Task<Student> UpdateStudent(Student student)
    {
        student.BirthDate = DateTime.SpecifyKind(student.BirthDate, DateTimeKind.Utc);
        var find = await dataContext.Students.FindAsync(student.Id);
        find.FirstName = student.FirstName;
        find.LastName = student.LastName;
        find.Address = student.Address;
        find.EmailAddress = student.EmailAddress;
        find.BirthDate = student.BirthDate;
        find.PhoneNumber = student.PhoneNumber;
        find.TelegramUserName = student.TelegramUserName;
        find.FileName = student.FileName;
        find.Status = student.Status;
        await dataContext.SaveChangesAsync();
        return student;
    }
    public async Task<bool> DeleteStudent(int id)
    {
        var find = await dataContext.Students.FindAsync(id);
        dataContext.Students.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }
}
