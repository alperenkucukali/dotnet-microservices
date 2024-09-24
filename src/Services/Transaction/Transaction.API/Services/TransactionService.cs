using AutoMapper;
using Transaction.API.Data.DTOs.Requests;
using Transaction.API.Data.DTOs.Responses;
using Transaction.API.Repositories.Interfaces;
using Transaction.API.Services.Interfaces;

namespace Transaction.API.Services
{
    public class TransactionService(
        ITransactionRepository transactionRepository,
        IMapper mapper)
        : ITransactionService
        {
        public async Task<List<TransactionDto>> GetByAccountId(Guid accountId)
        {
            var transactions = await transactionRepository.GetByAccountId(accountId);
            return mapper.Map<List<TransactionDto>>(transactions)!;
        }

        public async Task<List<TransactionDto>> GetWithFilter(RequestFilter filter)
        {
            var transactions = await transactionRepository.GetWithFilter(filter);
            return mapper.Map<List<TransactionDto>>(transactions)!;
        }
    }
}
