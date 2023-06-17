using MediatR;
using TasksService.Application.Task.Models;

namespace TasksService.Application.Task.Commands.Contracts;

public sealed record UpdateTaskCommand(
    int Id,
    string Name,
    string Description,
    string Status) : IRequest<UpdateTaskResult>;