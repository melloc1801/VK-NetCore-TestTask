using Microsoft.AspNetCore.Mvc;
using VK.Application.Features.StateFeature;
using VK.Application.Features.StateFeature.dtos;

namespace VK.WebAPI.Controllers;

[ApiController]
[Route("/state")]
public class UserStatesController
{
    private readonly IStateService _stateService;

    public UserStatesController(IStateService stateService)
    {
        _stateService = stateService;
    }
    
    [HttpPost]
    public Task<int> Create([FromBody] CreateStateDto createStateDto)
    {
        return _stateService.Create(createStateDto);
    }

    [HttpGet]
    public async Task<GetStateDto[]> GetAll()
    {
        var states = await _stateService.GetAll();

        return states.Select(state => new GetStateDto(state.Id, state.Code, state.Description)).ToArray();
    }
}