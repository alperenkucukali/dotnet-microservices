using System.Linq.Expressions;

namespace Customer.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IRepositoryBase<Domain.Entities.Customer>
    {
        Task<bool> AnyAsync(Expression<Func<Domain.Entities.Customer, bool>> predicate);
    }
}
