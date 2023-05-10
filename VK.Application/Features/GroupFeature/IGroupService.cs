using VK.Application.Features.GroupFeature.Dtos;
using VK.Domain.Entities;

namespace VK.Application.Features.GroupFeature;

public interface IGroupService
{
    Task<int> Create(CreateGroupDto createGroupDto);
    Task<UserGroup[]> GetAll();
    Task<UserGroup?> GetOneByCode(string code);
}