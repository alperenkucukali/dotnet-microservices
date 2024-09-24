using Customer.Application.Contracts.Persistence;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
