using VK.Domain.Entities;

namespace VK.Application.Features.UserFeature.Dtos;

public class GetUserDto
{
    public int Id { get; }
    public string Login { get; }
    public string Password { get; }
    public DateTime CreatedDate { get; }
    public UserGroup UserGroup { get; }
    public UserState UserState { get; }

    public GetUserDto(
        int id,
        string login, 
        string password, 
        DateTime createdDate, 
        UserGroup userGroup, 
        UserState userState
    )
    {
        Id = id;
        Login = login;
        Password = password;
        CreatedDate = createdDate;
        UserGroup = userGroup;
        UserState = userState;
    }
}