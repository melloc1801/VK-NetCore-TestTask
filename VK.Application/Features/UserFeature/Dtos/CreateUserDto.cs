namespace VK.Application.Features.UserFeature.Dtos;

public class CreateUserDto: CreateUserRequestBodyDto
{
    public DateTime CreatedDate { get; }
    public int UserStateId { get; }

    public CreateUserDto(
        string login, 
        string password, 
        DateTime createdDate,
        int userGroupId,
        int userStateId
    ): base(login, password, userGroupId)
    {
        CreatedDate = createdDate;
        UserStateId = userStateId;
    }
}