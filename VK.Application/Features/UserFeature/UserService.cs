using VK.Application.Features.UserFeature.Dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;

namespace VK.Application.Features.UserFeature;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> CreateUser(CreateUserRequestBodyDto createUserRequestBodyDto)
    {
        var createUserDto = new CreateUserDto(
            createUserRequestBodyDto.Login, 
            createUserRequestBodyDto.Password, 
            DateTime.UtcNow, 
            createUserRequestBodyDto.UserGroupId,
            1
        );

        return await _userRepository.Create(createUserDto);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<User[]> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }
}