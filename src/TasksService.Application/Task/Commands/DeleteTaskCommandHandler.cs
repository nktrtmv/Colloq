using System.Text;
using JetBrains.Annotations;
using MediatR;
using TasksService.Application.Task.Commands.Contracts;
using TasksService.Application.Task.Models;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Task.Commands;

[UsedImplicitly]
public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskResult>
{
    private readonly ITasksService _tasksService;

    public DeleteTaskCommandHandler(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    public async Task<DeleteTaskResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _tasksService.Delete(request.Id, cancellationToken);

        return new DeleteTaskResult();
    }
}