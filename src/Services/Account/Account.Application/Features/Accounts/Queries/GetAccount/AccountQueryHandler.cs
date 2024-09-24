using Account.Application.Contracts.Persistence;
using Account.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Features.Accounts.Queries.GetAccount
{
    public class AccountQueryHandler : IRequestHandler<AccountQuery, GetAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountQueryHandler> _logger;

        public AccountQueryHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<AccountQueryHandler> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetAccountResponse> Handle(AccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAsync(x => x.Id == request.AccountId && x.CustomerId == request.CustomerId);
            if (account is null)
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            if (account.CustomerId != request.AccountId)
                throw new UnauthorizedAccessException();
            return _mapper.Map<GetAccountResponse>(account)!;
        }
    }
}
