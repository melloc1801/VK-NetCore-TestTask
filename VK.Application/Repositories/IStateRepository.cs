using VK.Application.Features.StateFeature.dtos;
using VK.Domain.Entities;

namespace VK.Application.Repositories;

public interface IStateRepository
{
    Task<int> Create(CreateStateDto createStateDto);
    Task<UserState[]> GetAll();
    Task<UserState?> GetOneByCode(string code);
}