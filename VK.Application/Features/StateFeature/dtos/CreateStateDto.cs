namespace VK.Application.Features.StateFeature.dtos;

public class CreateStateDto
{
    public string Code { get; }
    public string? Description { get; }

    public CreateStateDto(string code, string? description = null)
    {
        Code = code;
        Description = description;
    }
}