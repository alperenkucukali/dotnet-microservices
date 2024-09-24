using Account.Application.Contracts.Persistence;
using Account.Infrastructure.Persistence;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository(AccountContext dbContext)
        : RepositoryBase<Domain.Entities.Account>(dbContext), IAccountRepository;
}
