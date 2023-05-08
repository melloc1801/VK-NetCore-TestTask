using Microsoft.Extensions.DependencyInjection;
using VK.Application.Features.UserFeature;

namespace VK.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}