using Microsoft.EntityFrameworkCore;
using VK.Application.Features.StateFeature.dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Infrastructure.Persistence.Context;

namespace VK.Infrastructure.Persistence.Repositories;

public class StateRepository: IStateRepository
{
    private readonly DataContext _dataContext;

    public StateRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<int> Create(CreateStateDto createStateDto)
    {
        var state = new UserState();
        state.Code = createStateDto.Code;
        state.Description = createStateDto.Description;
        
        var newState = await _dataContext.UserStates.AddAsync(state);
        await _dataContext.SaveChangesAsync();
        return newState.Entity.Id;
    }

    public async Task<UserState[]> GetAll()
    {
        return await _dataContext.UserStates.ToArrayAsync();
    }

    public async Task<UserState?> GetOneByCode(string code)
    {
        return await _dataContext.UserStates.FirstOrDefaultAsync(state => state.Code == code);
    }

    public async Task<UserState?> FindOneById(int id)
    {
        return await _dataContext.UserStates.FirstOrDefaultAsync(state => state.Id == id);
    }
}