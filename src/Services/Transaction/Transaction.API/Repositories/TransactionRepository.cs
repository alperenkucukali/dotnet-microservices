using MongoDB.Driver;
using Transaction.API.Data.DTOs.Requests;
using Transaction.API.Data.Interfaces;
using Transaction.API.Repositories.Interfaces;

namespace Transaction.API.Repositories
{
    public class TransactionRepository(ITransactionContext transactionContext) : ITransactionRepository
        {
        public async Task Add(Entities.Transaction transaction)
        {
            await transactionContext.Transactions.InsertOneAsync(transaction);
        }

        public async Task<IEnumerable<Entities.Transaction>> GetByAccountId(Guid accountId)
        {
            return await transactionContext
                .Transactions
                .Find(x => x.AccountId == accountId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Entities.Transaction>> GetWithFilter(RequestFilter filter)
        {
            var filterBuilder = Builders<Entities.Transaction>.Filter;

            var filters = filterBuilder.Eq(x => x.CustomerId, filter.CustomerId) &
                filterBuilder.Gte(x => x.CreatedDate, filter.StartDate) &
                filterBuilder.Lt(x => x.CreatedDate, filter.EndDate);

            return await transactionContext
                .Transactions
                .Find(filters)
                .ToListAsync();
        }
    }
}
