using VK.Application.Features.UserFeature.Dtos;
using VK.Domain.Entities;

namespace VK.Application.Repositories;

public interface IUserRepository
{
    Task<int> Create(CreateUserDto createUserDto);
    Task<User?> GetUserById(int id);
    Task<User[]> GetAllUsers();
    Task DeleteUser(int id);
    Task<User?> GetAdmin();
}