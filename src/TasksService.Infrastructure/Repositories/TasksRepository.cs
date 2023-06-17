using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using TasksService.Infrastructure.Abstractions.Entities;
using TasksService.Infrastructure.Abstractions.Repositories;
using TasksService.Infrastructure.Repositories.Abstractions;
using TasksService.Infrastructure.Settings;

namespace TasksService.Infrastructure.Repositories;

public sealed class TasksRepository : BaseRepository, ITasksRepository
{
    public TasksRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<int> Create(TaskEntity entity, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            entity.Name,
            entity.Description,
            entity.Status,
            entity.CreatedAt
        };

        int id = await connection.ExecuteAsync(
            new CommandDefinition(
                TaskRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));

        return id;
    }

    public async Task Update(TaskEntity entity, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Status,
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                TaskRepositoryQueries.Update,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            Id = id
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                TaskRepositoryQueries.Delete,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task<TaskEntity> Query(int id, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            Id = id
        };

        var tasks = await connection.QueryAsync<TaskEntity>(
            new CommandDefinition(
                TaskRepositoryQueries.Query,
                sqlParams,
                cancellationToken: cancellationToken));

        return tasks.Single();
    }

    public async Task<TaskEntity[]> QueryAll(CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new { };

        var tasks = await connection.QueryAsync<TaskEntity>(
            new CommandDefinition(
                TaskRepositoryQueries.QueryAll,
                sqlParams,
                cancellationToken: cancellationToken));

        return tasks.ToArray();
    }
}