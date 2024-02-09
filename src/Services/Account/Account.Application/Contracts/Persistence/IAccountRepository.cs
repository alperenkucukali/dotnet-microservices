using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Contracts.Persistence
{
    public interface IAccountRepository : IRepositoryBase<Domain.Entities.Account>
    {
    }
}
