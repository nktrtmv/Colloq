namespace TasksService.Infrastructure.Repositories;

internal static class TaskRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO tasks
(
    name,
    description,
    status,
    created_at
)
VALUES 
(
    @Name,
    @Description,
    @Status,
    @CreatedAt
)
";

    internal static string Query => @"select id, name, description, status, created_at from tasks where id = @Id";

    internal static string QueryAll => @"select id, name, description, status, created_at from tasks";

    internal static string Update => @"
UPDATE tasks
SET
    name = @Name,
    description = @Description,
    status = @Status
WHERE
    id = @Id;
";

    internal static string Delete => @"
DELETE FROM tasks
WHERE id = @TaskId;
";
}