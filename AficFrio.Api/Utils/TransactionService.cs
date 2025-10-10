using AficFrio.Api.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace AficFrio.Api.Utils
{
    public class TransactionService
    {
        private readonly DBRestaurante _context;

        public TransactionService(DBRestaurante context)
        {
            _context = context;
        }

        public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await action();

                await transaction.CommitAsync();

                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw;
            }
        }
    }
}
