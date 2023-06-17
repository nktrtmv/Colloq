using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TasksService.Infrastructure.Extensions;

public static class HostExtensions
{
    public static IHost MigrateUp(this IHost app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();

        return app;
    }
}