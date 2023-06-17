using System.Transactions;
using TasksService.Domain.Abstractions.Services;
using TasksService.Infrastructure.Abstractions.Entities;
using TasksService.Infrastructure.Abstractions.Repositories;

namespace TasksService.Domain.Services;

public sealed class TasksService : ITasksService
{
    private readonly ITasksRepository _tasksRepository;

    public TasksService(ITasksRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    public async Task<int> Create(
        string name,
        string description,
        DateTime createdAt,
        string status,
        CancellationToken cancellationToken)
    {
        var entity = new TaskEntity
        {
            Name = name,
            Description = description,
            CreatedAt = createdAt,
            Status = status
        };

        using TransactionScope transaction = _tasksRepository.CreateTransactionScope();

        var result = await _tasksRepository.Create(entity, cancellationToken);

        transaction.Complete();

        return result;
    }

    public async Task Update(
        int id,
        string name,
        string description,
        string status,
        CancellationToken cancellationToken)
    {
        var entity = new TaskEntity
        {
            Id = id,
            Name = name,
            Description = description,
            Status = status
        };

        using TransactionScope transaction = _tasksRepository.CreateTransactionScope();

        await _tasksRepository.Update(entity, cancellationToken);

        transaction.Complete();
    }

    public async Task Delete(
        int id,
        CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _tasksRepository.CreateTransactionScope();

        await _tasksRepository.Delete(id, cancellationToken);

        transaction.Complete();
    }

    public async Task<Abstractions.Models.Task> Get(
        int id,
        CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _tasksRepository.CreateTransactionScope();

        var result = await _tasksRepository.Query(id, cancellationToken);

        transaction.Complete();

        return new Abstractions.Models.Task(result.Id, result.Name, result.Description, result.CreatedAt,
            result.Status);
    }

    public async Task<Abstractions.Models.Task[]> GetAll(CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _tasksRepository.CreateTransactionScope();

        var result = await _tasksRepository.QueryAll(cancellationToken);

        transaction.Complete();

        return result
            .Select(e => new Abstractions.Models.Task(e.Id, e.Name, e.Description, e.CreatedAt, e.Status))
            .ToArray();
    }
}