using MediatR;
using TasksService.Application.Task.Models;
using TasksService.Application.Task.Queries.Contracts;
using TasksService.Domain.Abstractions.Services;

namespace TasksService.Application.Task.Queries;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, GetAllTasksResult>
{
    private readonly ITasksService _tasksService;

    public GetAllTasksQueryHandler(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    public async Task<GetAllTasksResult> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _tasksService.GetAll(cancellationToken);

        return new GetAllTasksResult(tasks);
    }
}