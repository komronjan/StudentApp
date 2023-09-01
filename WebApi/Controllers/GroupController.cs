using Domain.Entiti;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController
{
    private readonly GroupService groupService;

    public GroupController(GroupService _groupService)
    {
        groupService = _groupService;
    }
    [HttpGet ("GetGroups")]
    public async Task<List<Group>> GetGroups()
    {
        return await groupService.GetGroups();
    }
    [HttpGet("GetGroupById")]
    public async Task<Group> GetGroupById(int id)
    {
        return await groupService.GetGroupById(id);
    }
    [HttpPost("AddGroup")]
    public async Task<Group> AddGroup([FromForm] Group group)
    {
        return await groupService.CreateGroup(group);
    }
    [HttpPut("UpdateGroup")]
    public async Task<Group> UpdateGroup([FromForm] Group group)
    {
        return await groupService.UpdateGroup(group);
    }
    [HttpDelete("DeleteGroup")]
    public async Task<bool> DeleteGroup(int id)
    {
        return await groupService.DeleteGroup(id);
    }


}
