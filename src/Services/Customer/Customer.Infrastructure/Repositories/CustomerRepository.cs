using Customer.Application.Contracts.Persistence;
using Customer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.Infrastructure.Repositories
{
    public class CustomerRepository(CustomerContext dbContext)
        : RepositoryBase<Domain.Entities.Customer>(dbContext), ICustomerRepository
        {
    public async Task<bool> AnyAsync(Expression<Func<Domain.Entities.Customer, bool>> predicate)
        {
            return await DbContext.Customers
                .AnyAsync(predicate);
        }
    }
}
