using Transaction.API.Data.DTOs.Requests;
using Transaction.API.Data.DTOs.Responses;

namespace Transaction.API.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetByAccountId(Guid accountId);
        Task<List<TransactionDto>> GetWithFilter(RequestFilter filter);
    }
}
