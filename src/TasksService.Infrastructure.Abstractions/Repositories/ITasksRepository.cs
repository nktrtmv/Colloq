using TasksService.Infrastructure.Abstractions.Entities;

namespace TasksService.Infrastructure.Abstractions.Repositories;

public interface ITasksRepository : IDbRepository
{
    Task<int> Create(TaskEntity entity, CancellationToken cancellationToken);

    Task Update(TaskEntity entity, CancellationToken cancellationToken);

    Task Delete(int id, CancellationToken cancellationToken);

    Task<TaskEntity> Query(int id, CancellationToken cancellationToken);

    Task<TaskEntity[]> QueryAll(CancellationToken cancellationToken);
}