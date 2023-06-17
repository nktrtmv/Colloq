using System.Transactions;

namespace TasksService.Infrastructure.Abstractions.Repositories;

public interface IDbRepository
{
    TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted);
}