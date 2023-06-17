using MediatR;
using TasksService.Application.Task.Models;
using TasksService.Application.Task.Queries.Contracts;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Task.Queries;

public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, GetTaskResult>
{
    private readonly ITasksService _tasksService;

    public GetTaskQueryHandler(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    public async Task<GetTaskResult> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = await _tasksService.Get(request.Id, cancellationToken);

        return new GetTaskResult(task);
    }
}