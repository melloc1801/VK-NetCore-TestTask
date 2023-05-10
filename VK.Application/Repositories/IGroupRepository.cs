using VK.Application.Features.GroupFeature.Dtos;
using VK.Domain.Entities;

namespace VK.Application.Repositories;

public interface IGroupRepository
{
    Task<int> Create(CreateGroupDto createGroupDto);
    Task<UserGroup[]> GetAll();
    Task<UserGroup?> GetOneByCode(string code);
    Task<UserGroup?> FindOneById(int id);
}