namespace TasksService.Domain.Abstractions.Services;

public interface ITasksService
{
    Task<int> Create(string name, string description, DateTime createdAt, string status, CancellationToken cancellationToken);

    Task Update(int id, string name, string description, string status, CancellationToken cancellationToken);
    
    Task Delete(int id, CancellationToken cancellationToken);

    Task<Models.Task> Get(int id, CancellationToken cancellationToken);

    Task<Models.Task[]> GetAll(CancellationToken cancellationToken);
}