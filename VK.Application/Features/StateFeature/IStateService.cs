using VK.Application.Features.StateFeature.dtos;
using VK.Domain.Entities;

namespace VK.Application.Features.StateFeature;

public interface IStateService
{
    Task<int> Create(CreateStateDto createStateDto);
    Task<UserState[]> GetAll();
    Task<UserState?> GetOneByCode(string code);
}