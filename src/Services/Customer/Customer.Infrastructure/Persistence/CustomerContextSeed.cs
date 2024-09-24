using Microsoft.Extensions.Logging;

namespace Customer.Infrastructure.Persistence
{
    public class CustomerContextSeed
    {
        public static async Task SeedAsync(CustomerContext CustomerContext, ILogger<CustomerContextSeed> logger)
        {
            if (!CustomerContext.Customers.Any())
            {
                CustomerContext.Customers.AddRange(GetPreconfiguredCustomers());
                await CustomerContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(CustomerContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.Customer> GetPreconfiguredCustomers()
        {
            return new List<Domain.Entities.Customer>
            {
                new Domain.Entities.Customer(Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"), "alperen171195@hotmail.com", "Alperen", "Küçükali")
            };
        }
    }
}
