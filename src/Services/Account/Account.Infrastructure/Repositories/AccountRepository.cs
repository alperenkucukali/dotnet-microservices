using Account.Application.Contracts.Persistence;
using Account.Infrastructure.Persistence;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Domain.Entities.Account>, IAccountRepository
    {
        public AccountRepository(AccountContext dbContext) : base(dbContext)
        {
        }
    }
}
