using Microsoft.Extensions.DependencyInjection;
using VK.Application.Repositories;
using VK.Infrastructure.Persistence.Context;
using VK.Infrastructure.Persistence.Repositories;

namespace VK.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
    }
}