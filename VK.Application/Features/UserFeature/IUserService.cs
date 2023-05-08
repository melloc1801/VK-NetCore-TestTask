using VK.Application.Features.UserFeature.Dtos;
using VK.Domain.Entities;

namespace VK.Application.Features.UserFeature;
public interface IUserService
{
    Task<int> CreateUser(CreateUserRequestBodyDto createUserRequestBodyDto);

    Task<User?> GetUserById(int id);

    Task<User[]> GetAllUsers();
    Task DeleteUser(int id);
}