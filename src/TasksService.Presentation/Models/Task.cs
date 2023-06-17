namespace TasksService.Models;

public sealed record Task(int Id, string Name, string Description, string Status, DateTime CreatedAt);