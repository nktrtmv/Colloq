namespace TasksService.Domain.Abstractions.Models;

public sealed record Task(int Id, string Name, string Description, DateTime CreatedAt, string Status);