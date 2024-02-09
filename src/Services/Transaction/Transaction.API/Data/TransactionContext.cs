using MongoDB.Driver;
using Transaction.API.Data.Interfaces;

namespace Transaction.API.Data
{
    public class TransactionContext : ITransactionContext
    {
        public TransactionContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Transactions = database.GetCollection<Entities.Transaction>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            TransactionContextSeed.SeedData(Transactions);
        }

        public IMongoCollection<Entities.Transaction> Transactions { get; }
    }
}
