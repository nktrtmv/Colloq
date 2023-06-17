using System.Transactions;
using Npgsql;
using TasksService.Infrastructure.Abstractions.Repositories;
using TasksService.Infrastructure.Settings;

namespace TasksService.Infrastructure.Repositories.Abstractions;

public abstract class BaseRepository : IDbRepository
{
    private readonly DalOptions _dalSettings;

    protected BaseRepository(DalOptions dalSettings)
    {
        _dalSettings = dalSettings;
    }

    public TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        return new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = level,
                Timeout = TimeSpan.FromSeconds(5)
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }

    protected async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(_dalSettings.ConnectionString);
        await connection.OpenAsync();
        await connection.ReloadTypesAsync();

        return connection;
    }
}