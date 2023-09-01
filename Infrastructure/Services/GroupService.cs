namespace Infrastructure.Services;
using Domain.Entiti;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
public class GroupService
{
    private readonly DataContext dataContext;

    public GroupService(DataContext _dataContext)
    {
        dataContext = _dataContext;
    }
    public async Task<List<Group>> GetGroups()
    {
        return await dataContext.Groups.ToListAsync();
    }
    public async Task<Group> GetGroupById(int id)
    {
        return await dataContext.Groups.FindAsync(id);
    }
    public async Task<Group> CreateGroup(Group group)
    {
        group.StartsAt = DateTime.SpecifyKind(group.StartsAt, DateTimeKind.Utc);
        group.FinishedsAt = DateTime.SpecifyKind(group.FinishedsAt, DateTimeKind.Utc);
        await dataContext.Groups.AddAsync(group);
        await dataContext.SaveChangesAsync();
        return group;
    }
    public async Task<Group> UpdateGroup(Group group)
    {
        group.StartsAt = DateTime.SpecifyKind(group.StartsAt, DateTimeKind.Utc);
        group.FinishedsAt = DateTime.SpecifyKind(group.FinishedsAt, DateTimeKind.Utc);
        var find = await dataContext.Groups.FindAsync(group.Id);
        find.Course = group.Course;
        find.CourseFormal = group.CourseFormal;
        find.Description = group.Description;
        find.Duration = group.Duration;
        find.DurationType = group.DurationType;
        find.FinishedsAt = group.FinishedsAt;
        find.GroupName = group.GroupName;
        find.StartsAt = group.StartsAt;
        await dataContext.SaveChangesAsync();
        return group;
    }
    public async Task<bool> DeleteGroup(int id)
    {
        var find = await dataContext.Groups.FindAsync(id);
        dataContext.Groups.Remove(find);
        await dataContext.SaveChangesAsync();
        return true;
    }

}
