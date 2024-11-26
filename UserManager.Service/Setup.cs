using Microsoft.Extensions.DependencyInjection;
using UserManager.Domain.Interfaces;
using UserManager.ServiceApplication.Services;

namespace UserManager.ServiceApplication;

public static class Setup
{
    public static IServiceCollection AddServicesApplication(this IServiceCollection services)
    {
        services.AddScoped<IServices, Service>();
        return services;
    }
}
