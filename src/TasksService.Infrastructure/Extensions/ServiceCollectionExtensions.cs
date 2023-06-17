using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TasksService.Infrastructure.Abstractions.Repositories;
using TasksService.Infrastructure.Repositories;
using TasksService.Infrastructure.Settings;

namespace TasksService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDalRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITasksRepository, TasksRepository>();

        return services;
    }

    public static IServiceCollection AddDalInfrastructure(
        this IServiceCollection services,
        IConfigurationRoot config)
    {
        //read config
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        //configure postgres types
        Postgres.MapCompositeTypes();

        //add migrations
        Postgres.AddMigrations(services);

        return services;
    }
}