namespace VK.Application.Features.UserFeature.Dtos;

public class CreateUserRequestBodyDto
{
    public string Login { get; }
    public string Password { get; }
    public int UserGroupId { get; }

    public CreateUserRequestBodyDto(
        string login, 
        string password,
        int userGroupId
    )
    {
        Login = login;
        Password = password;
        UserGroupId = userGroupId;
    }
}