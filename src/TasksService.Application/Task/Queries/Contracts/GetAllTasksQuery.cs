using MediatR;
using TasksService.Application.Task.Models;

namespace TasksService.Application.Task.Queries.Contracts;

public sealed record GetAllTasksQuery : IRequest<GetAllTasksResult>;