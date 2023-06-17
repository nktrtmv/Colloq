using MediatR;
using TasksService.Application.Task.Models;

namespace TasksService.Application.Task.Commands.Contracts;

public sealed record DeleteTaskCommand(int Id) : IRequest<DeleteTaskResult>;