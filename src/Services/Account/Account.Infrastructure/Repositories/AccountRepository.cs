using Account.Application.Contracts.Persistence;
using Account.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Domain.Entities.Account>, IAccountRepository
    {
        public AccountRepository(AccountContext dbContext) : base(dbContext)
        {
        }
    }
}
