using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IRepositoryBase<Domain.Entities.Customer>
    {
        Task<bool> AnyAsync(Expression<Func<Domain.Entities.Customer, bool>> predicate);
    }
}
