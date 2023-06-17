using Microsoft.Extensions.DependencyInjection;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<ITasksService, Domain.Services.TasksService>();

        return services;
    }
}