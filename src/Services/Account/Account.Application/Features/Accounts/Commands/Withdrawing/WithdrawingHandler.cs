using Account.Application.Contracts.Persistence;
using Account.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Features.Accounts.Commands.Withdrawing
{
    public class WithdrawingHandler : IRequestHandler<WithdrawingCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WithdrawingHandler> _logger;

        public WithdrawingHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<WithdrawingHandler> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(WithdrawingCommand request, CancellationToken cancellationToken)
        {
            var accountUpdate = await _accountRepository.GetByIdAsync(request.AccountId);
            if (accountUpdate is null)
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            if (accountUpdate.CustomerId != request.CustomerId)
                throw new UnauthorizedAccessException();
            if (accountUpdate.Balance < request.Amount)
                throw new InsufficientBalanceException(accountUpdate.Balance);
            accountUpdate.Balance -= request.Amount;
            await _accountRepository.UpdateAsync(accountUpdate);
            return Unit.Value;
        }

        Task IRequestHandler<WithdrawingCommand>.Handle(WithdrawingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
