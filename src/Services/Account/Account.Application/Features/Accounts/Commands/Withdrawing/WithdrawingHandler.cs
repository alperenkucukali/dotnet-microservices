// using Account.Application.Contracts.Persistence;
// using Account.Application.Exceptions;
// using AutoMapper;
// using MediatR;
// using Microsoft.Extensions.Logging;
//
// namespace Account.Application.Features.Accounts.Commands.Withdrawing
// {
//     public class WithdrawingHandler(
//         IAccountRepository accountRepository,
//         IMapper mapper,
//         ILogger<WithdrawingHandler> logger)
//         : IRequestHandler<WithdrawingCommand>
//         {
//         private readonly IMapper _mapper = mapper;
//         private readonly ILogger<WithdrawingHandler> _logger = logger;
//
//         public async Task<Unit> Handle(WithdrawingCommand request, CancellationToken cancellationToken)
//         {
//             var accountUpdate = await accountRepository.GetByIdAsync(request.AccountId);
//             if (accountUpdate is null)
//                 throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
//             if (accountUpdate.CustomerId != request.CustomerId)
//                 throw new UnauthorizedAccessException();
//             if (accountUpdate.Balance < request.Amount)
//                 throw new InsufficientBalanceException(accountUpdate.Balance);
//             accountUpdate.Balance -= request.Amount;
//             await accountRepository.UpdateAsync(accountUpdate);
//             return Unit.Value;
//         }
//     }
// }
