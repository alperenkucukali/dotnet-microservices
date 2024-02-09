using MongoDB.Driver;

namespace Transaction.API.Data.Interfaces
{
    public interface ITransactionContext
    {
        IMongoCollection<Entities.Transaction> Transactions { get; }
    }
}
