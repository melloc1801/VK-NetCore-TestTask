using VK.Application.Features.StateFeature.dtos;
using VK.Application.Repositories;
using VK.Domain.Entities;
using VK.Domain.Exceptions;

namespace VK.Application.Features.StateFeature;

public class StateService: IStateService
{
    private readonly IStateRepository _stateRepository;
    
    public StateService(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }
    
    public async Task<int> Create(CreateStateDto createStateDto)
    {
        var state = await _stateRepository.GetOneByCode(createStateDto.Code);
        if (state != null)
        {
            throw new BadRequestException("State already exists");
        }
        
        return await _stateRepository.Create(createStateDto);
    }

    public async Task<UserState[]> GetAll()
    {
        return await _stateRepository.GetAll();
    }

    public async Task<UserState?> GetOneByCode(string code)
    {
        return await _stateRepository.GetOneByCode(code);
    }
}