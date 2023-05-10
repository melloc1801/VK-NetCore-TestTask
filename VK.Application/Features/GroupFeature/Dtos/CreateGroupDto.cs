namespace VK.Application.Features.GroupFeature.Dtos;

public class CreateGroupDto
{
    public string Code { get; }
    public string? Description { get; }

    public CreateGroupDto(string code, string? description = null)
    {
        Code = code;
        Description = description;
    }
}