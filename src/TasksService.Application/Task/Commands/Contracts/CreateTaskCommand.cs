using MediatR;
using TasksService.Application.Task.Models;

namespace TasksService.Application.Task.Commands.Contracts;

public sealed record CreateTaskCommand(string Name, string Description) : IRequest<CreateTaskResult>;