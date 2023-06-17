using System.Text;
using JetBrains.Annotations;
using MediatR;
using TasksService.Application.Task.Commands.Contracts;
using TasksService.Application.Task.Models;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Task.Commands;

[UsedImplicitly]
public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskResult>
{
    private readonly ITasksService _tasksService;

    public UpdateTaskCommandHandler(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    public async Task<UpdateTaskResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        await _tasksService.Update(request.Id, request.Name, request.Description, request.Status, cancellationToken);

        return new UpdateTaskResult();
    }
}