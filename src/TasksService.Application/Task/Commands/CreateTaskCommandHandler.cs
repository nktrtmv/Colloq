using System.Text;
using JetBrains.Annotations;
using MediatR;
using TasksService.Application.Task.Commands.Contracts;
using TasksService.Application.Task.Models;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Task.Commands;

[UsedImplicitly]
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResult>
{
    private readonly ITasksService _tasksService;

    public CreateTaskCommandHandler(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    public async Task<CreateTaskResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {

        var resultId = await _tasksService.Create(request.Name, request.Description, DateTime.UtcNow, "Not started", cancellationToken);
        
        return new CreateTaskResult(resultId);
    }
}