using Microsoft.Extensions.DependencyInjection;
using VK.Application.Features.GroupFeature;
using VK.Application.Features.StateFeature;
using VK.Application.Features.UserFeature;

namespace VK.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IStateService, StateService>();
    }
}