namespace TasksService.Infrastructure.Settings;

public sealed record DalOptions
{
    public string ConnectionString { get; init; } = string.Empty;
}