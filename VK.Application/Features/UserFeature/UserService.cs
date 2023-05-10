using Microsoft.Extensions.Caching.Memory;
using VK.Application.Features.UserFeature.Dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Domain.Exceptions;

namespace VK.Application.Features.UserFeature;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IStateRepository _stateRepository;
    private readonly IMemoryCache _cache;

    public UserService(
        IUserRepository userRepository, 
        IGroupRepository groupRepository, 
        IStateRepository stateRepository,
        IMemoryCache cache
        )
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _stateRepository = stateRepository;
        _cache = cache;
    }

    public async Task<int> CreateUser(CreateUserRequestBodyDto createUserRequestBodyDto)
    {
        if (_cache.Get<bool>(createUserRequestBodyDto.Login))
        {
            throw new BadRequestException("User with login is creating");
        }

        var userWithLogin = await _userRepository.FindByLogin(createUserRequestBodyDto.Login);
        if (userWithLogin != null)
        {
            throw new BadRequestException("User with login already exists");
        }

        var group = await _groupRepository.FindOneById(createUserRequestBodyDto.UserGroupId);
        if (group == null)
        {
            throw new BadRequestException("Group not found");
        }

        if (group.Code == "Admin")
        {
            var admin = await _userRepository.GetAdmin();
            if (admin != null)
            {
                throw new BadRequestException("Admin already exists");
            }
        }

        var state = await _stateRepository.GetOneByCode("Active");
        if (state == null)
        {
            throw new BadRequestException("Active state not found");
        }
        
        var createUserDto = new CreateUserDto(
            createUserRequestBodyDto.Login, 
            createUserRequestBodyDto.Password, 
            DateTime.UtcNow, 
            group.Id,
            state.Id
        );

        var userId = await _userRepository.Create(createUserDto);
        var user = await _userRepository.GetUserById(userId);

        _cache.Set(user.Login, true, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20)
        });
        return userId;
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
        var blockedState = await _stateRepository.GetOneByCode("Blocked");
        if (blockedState == null)
        {
            throw new BadRequestException("Blocked status not found");
        }
        await _userRepository.DeleteUser(id, blockedState);
    }
}