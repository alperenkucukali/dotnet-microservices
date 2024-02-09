using AutoMapper;
using Transaction.API.Data.DTOs.Requests;
using Transaction.API.Data.DTOs.Responses;
using Transaction.API.Repositories.Interfaces;
using Transaction.API.Services.Interfaces;

namespace Transaction.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<TransactionService> _logger;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, ILogger<TransactionService> logger, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<TransactionDto>> GetByAccountId(Guid accountId)
        {
            var transactions = await _transactionRepository.GetByAccountId(accountId);
            return _mapper.Map<List<TransactionDto>>(transactions)!;
        }

        public async Task<List<TransactionDto>> GetWithFilter(RequestFilter filter)
        {
            var transactions = await _transactionRepository.GetWithFilter(filter);
            return _mapper.Map<List<TransactionDto>>(transactions)!;
        }
    }
}
