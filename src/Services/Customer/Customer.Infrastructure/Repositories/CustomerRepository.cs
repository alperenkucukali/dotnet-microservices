using Customer.Application.Contracts.Persistence;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Domain.Entities.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Customer, bool>> predicate)
        {
            return await _dbContext.Customers
                .AnyAsync(predicate);
        }
    }
}
