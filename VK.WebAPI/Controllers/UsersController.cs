using Microsoft.AspNetCore.Mvc;
using VK.Application.Features.UserFeature;
using VK.Application.Features.UserFeature.Dtos;

namespace VK.WebAPI.Controllers;

[ApiController]
[Route("/user")]
public class UsersController
{
    private readonly IUserService _userService;
    
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public Task<int> CreateUser([FromBody]CreateUserRequestBodyDto createUserRequestBodyDto)
    {
        return _userService.CreateUser(createUserRequestBodyDto);
    }

    [HttpGet("{userId}")]
    public async Task<GetUserDto?> GetUser(int userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null)
        {
            return null;
        }
        
        return new GetUserDto(user.Id, user.Login, user.Password, user.CreatedDate, user.UserGroup, user.UserState);
    }

    [HttpGet("all")]
    public async Task<GetUserDto[]> GetUsers()
    {
        var users = await _userService.GetAllUsers();
        
        return users
            .Select(u => new GetUserDto(
                u.Id,
                u.Login,
                u.Password,
                u.CreatedDate,
                u.UserGroup,
                u.UserState
            ))
            .ToArray();
    }

    [HttpDelete("{userId}")]
    public void DeleteUser(int userId)
    {
        _userService.DeleteUser(userId);
    }
}