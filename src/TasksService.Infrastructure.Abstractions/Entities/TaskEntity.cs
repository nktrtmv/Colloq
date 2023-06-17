namespace TasksService.Infrastructure.Abstractions.Entities;

public sealed record TaskEntity
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}