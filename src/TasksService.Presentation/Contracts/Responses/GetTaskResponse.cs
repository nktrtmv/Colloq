using Task = TasksService.Models.Task;

namespace TasksService.Contracts.Responses;

public sealed record GetTaskResponse(Task Task);