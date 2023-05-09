using Microsoft.AspNetCore.Mvc;
using VK.Application.Features.GroupFeature;
using VK.Application.Features.GroupFeature.Dtos;

namespace VK.WebAPI.Controllers;

[ApiController]
[Route("/group")]
public class UserGroupsController
{
    private readonly IGroupService _groupService;
    
    public UserGroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    public async Task<int> Create([FromBody] CreateGroupDto createGroupDto)
    {
        return await _groupService.Create(createGroupDto);
    }

    [HttpGet]
    public async Task<GetGroupDto[]> GetAll()
    {
        var groups = await _groupService.GetAll();

        return groups
            .Select(group => new GetGroupDto(
                group.Id, 
                group.Code,
                group.Description)
            ).ToArray();
    }
}