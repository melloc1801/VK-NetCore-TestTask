using VK.Application.Features.GroupFeature.Dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Domain.Exceptions;

namespace VK.Application.Features.GroupFeature;

public class GroupService: IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<int> Create(CreateGroupDto createGroupDto)
    {
        var group = await _groupRepository.GetOneByCode(createGroupDto.Code);
        if (group != null)
        {
            throw new BadRequestException("Group already exists");
        }
        
        return await _groupRepository.Create(createGroupDto);
    }

    public async Task<UserGroup[]> GetAll()
    {
        return await _groupRepository.GetAll();
    }

    public async Task<UserGroup?> GetOneByCode(string code)
    {
        return await _groupRepository.GetOneByCode(code);
    }
}