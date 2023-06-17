namespace TasksService.Contracts.Requests;

public sealed record CreateTaskRequest(string Name, string Description);