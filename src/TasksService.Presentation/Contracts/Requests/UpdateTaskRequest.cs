namespace TasksService.Contracts.Requests;

public sealed record UpdateTaskRequest(
    int Id,
    string Name,
    string Description,
    string Status);