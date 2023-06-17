using MediatR;
using Microsoft.AspNetCore.Mvc;
using TasksService.Application.Task.Commands.Contracts;
using TasksService.Application.Task.Queries.Contracts;
using TasksService.Contracts.Requests;
using TasksService.Contracts.Responses;
using TasksService.Contracts.Validators;
using TasksService.Models;
using Exception = System.Exception;
using Task = TasksService.Models.Task;

namespace TasksService.Controllers;

[Route("[controller]")]
public sealed class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all-tasks")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllTasksResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllTasks(
        CancellationToken token)
    {
        try
        {
            var query = new GetAllTasksQuery();

            var result = await _mediator.Send(query, token);

            Task[] tasks = result.Tasks
                .Select(t => new Task(t.Id, t.Name, t.Description, t.Status, t.CreatedAt))
                .ToArray();

            return Ok(new GetAllTasksResponse(tasks));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("get-task")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTaskResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTask(
        GetTaskRequest request,
        CancellationToken token)
    {
        try
        {
            var query = new GetTaskQuery(request.Id);

            var result = await _mediator.Send(query, token);

            var task = new Task(result.Task.Id, result.Task.Name, result.Task.Description, result.Task.Status,
                result.Task.CreatedAt);

            return Ok(new GetTaskResponse(task));
        }
        catch (Exception)
        {
            return BadRequest($"There is no task with id: {request.Id}.");
        }
    }

    [HttpPost("create-task")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateTaskResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTask(
        CreateTaskRequest request,
        CancellationToken token)
    {
        try
        {
            CreateTaskValidator.ValidateName(request);
            CreateTaskValidator.ValidateDescription(request);

            var command = new CreateTaskCommand(request.Name, request.Description);

            var result = await _mediator.Send(command, token);

            return Ok(new CreateTaskResponse(result.Id));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("update-task")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask(
        UpdateTaskRequest request,
        CancellationToken token)
    {
        try
        {
            UpdateTaskValidator.ValidateName(request);
            UpdateTaskValidator.ValidateDescription(request);
            UpdateTaskValidator.ValidateStatus(request);

            var command = new UpdateTaskCommand(request.Id, request.Name, request.Description, request.Status);

            await _mediator.Send(command, token);

            return Ok("Success.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest($"There is no task with id: {request.Id}.");
        }
    }

    [HttpDelete("delete-task")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTask(
        DeleteTaskRequest request,
        CancellationToken token)
    {
        try
        {
            var command = new DeleteTaskCommand(request.Id);

            await _mediator.Send(command, token);

            return Ok("Success.");
        }
        catch (Exception)
        {
            return BadRequest($"There is no task with id: {request.Id}.");
        }
    }
}