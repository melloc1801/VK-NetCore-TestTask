using Microsoft.EntityFrameworkCore;
using VK.Application.Features.GroupFeature.Dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Infrastructure.Persistence.Context;

namespace VK.Infrastructure.Persistence.Repositories;

public class GroupRepository: IGroupRepository
{
    private readonly DataContext _context;

    public GroupRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<int> Create(CreateGroupDto createGroupDto)
    {
        var group = new UserGroup();
        group.Code = createGroupDto.Code;
        group.Description = createGroupDto.Description;
        
        var newGroup = await _context.UserGroups.AddAsync(group);
        await _context.SaveChangesAsync();

        return newGroup.Entity.Id;
    }

    public async Task<UserGroup[]> GetAll()
    {
        return await _context.UserGroups.ToArrayAsync();
    }

    public async Task<UserGroup?> GetOneByCode(string code)
    {
        return await _context.UserGroups.FirstOrDefaultAsync(group => group.Code == code);
    }
}