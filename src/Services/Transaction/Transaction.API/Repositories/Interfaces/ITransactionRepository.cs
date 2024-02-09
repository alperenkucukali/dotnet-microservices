using Transaction.API.Data.DTOs.Requests;

namespace Transaction.API.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task Add(Entities.Transaction transaction);
        Task<IEnumerable<Entities.Transaction>> GetByAccountId(Guid accountId);
        Task<IEnumerable<Entities.Transaction>> GetWithFilter(RequestFilter filter);
    }
}
