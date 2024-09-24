using Account.Application.Contracts.Persistence;
using Account.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Features.Accounts.Commands.Adding
{
    public class AddingHandler : IRequestHandler<AddingCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddingHandler> _logger;

        public AddingHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<AddingHandler> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddingCommand request, CancellationToken cancellationToken)
        {
            var accountUpdate = await _accountRepository.GetByIdAsync(request.AccountId);
            if (accountUpdate is null)
                throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
            if (accountUpdate.CustomerId != request.CustomerId)
                throw new UnauthorizedAccessException();
            accountUpdate.Balance += request.Amount;
            await _accountRepository.UpdateAsync(accountUpdate);
            return Unit.Value;
        }

        Task IRequestHandler<AddingCommand>.Handle(AddingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
