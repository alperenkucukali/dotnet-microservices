using Microsoft.Extensions.Logging;

namespace Account.Infrastructure.Persistence
{
    public class AccountContextSeed
    {
        public static async Task SeedAsync(AccountContext AccountContext, ILogger<AccountContextSeed> logger)
        {
            if (!AccountContext.Accounts.Any())
            {
                AccountContext.Accounts.AddRange(GetPreconfiguredAccounts());
                await AccountContext.SaveChangesAsync();
                logger.LogInformation($"Seed database associated with context {typeof(AccountContext).Name}");
            }
        }

        private static IEnumerable<Domain.Entities.Account> GetPreconfiguredAccounts()
        {
            return new List<Domain.Entities.Account>
            {
                new Domain.Entities.Account(Guid.Parse("a3372135-ea3d-4eb9-8209-5a36634b2bba"),Guid.Parse("ef533977-e666-4c75-ac4e-ea1de9ea4aef"), 1_000_000)
            };
        }
    }
}
