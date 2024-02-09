using EventBus.Messages.Events;
using MongoDB.Driver;

namespace Transaction.API.Data
{
    public class TransactionContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Transaction> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }
        private static IEnumerable<Entities.Transaction> GetPreconfiguredProducts()
        {
            return new List<Entities.Transaction>()
            {
                new ()
                {
                    Id = Guid.NewGuid(),
                    AccountId = Guid.Parse("a3372135-ea3d-4eb9-8209-5a36634b2bba"),
                    Amount = 1_000_000,
                    CustomerId = Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"),
                    Type = TransactionType.Adding,
                    CreatedDate = DateTime.UtcNow
                }
            };
        }
    }
}
