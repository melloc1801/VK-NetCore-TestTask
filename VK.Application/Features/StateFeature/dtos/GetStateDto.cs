namespace VK.Application.Features.StateFeature.dtos;

public class GetStateDto
{
    public int Id { get; }
    public string Code { get; }
    public string? Description { get; }

    public GetStateDto(int id, string code, string? description = null)
    {
        Id = id;
        Code = code;
        Description = description;
    }
}