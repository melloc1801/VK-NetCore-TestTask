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

    public UserService(
        IUserRepository userRepository, 
        IGroupRepository groupRepository, 
        IStateRepository stateRepository
        )
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _stateRepository = stateRepository;
    }

    public async Task<int> CreateUser(CreateUserRequestBodyDto createUserRequestBodyDto)
    {
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
        var blockedState = await _stateRepository.GetOneByCode("Blocked");
        if (blockedState == null)
        {
            throw new BadRequestException("Blocked status not found");
        }
        await _userRepository.DeleteUser(id, blockedState);
    }
}