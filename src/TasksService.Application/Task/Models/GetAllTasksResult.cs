namespace TasksService.Application.Task.Models;

public record GetAllTasksResult(Domain.Abstractions.Models.Task[] Tasks);