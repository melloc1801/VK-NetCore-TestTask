namespace VK.Application.Features.GroupFeature.Dtos;

public class GetGroupDto
{
    public int Id { get; }
    public string Code { get; }
    public string? Description { get; }

    public GetGroupDto(int id, string code, string? description = null)
    {
        Id = id;
        Code = code;
        Description = description;
    }
}