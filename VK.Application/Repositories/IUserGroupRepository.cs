using VK.Domain.Entities;

namespace VK.Application.Repositories;

public interface IUserGroupRepository
{
    Task<UserGroup[]> GetAllGroups();
}