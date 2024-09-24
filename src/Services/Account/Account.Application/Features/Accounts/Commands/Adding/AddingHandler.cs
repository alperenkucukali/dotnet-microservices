// using Account.Application.Contracts.Persistence;
// using Account.Application.Exceptions;
// using AutoMapper;
// using MediatR;
// using Microsoft.Extensions.Logging;
//
// namespace Account.Application.Features.Accounts.Commands.Adding
// {
//     public class AddingHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<AddingHandler> logger)
//         : IRequestHandler<AddingCommand>
//         {
//         private readonly IMapper _mapper = mapper;
//         private readonly ILogger<AddingHandler> _logger = logger;
//
//         public async Task<Unit> Handle(AddingCommand request, CancellationToken cancellationToken)
//         {
//             var accountUpdate = await accountRepository.GetByIdAsync(request.AccountId);
//             if (accountUpdate is null)
//                 throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
//             if (accountUpdate.CustomerId != request.CustomerId)
//                 throw new UnauthorizedAccessException();
//             accountUpdate.Balance += request.Amount;
//             await accountRepository.UpdateAsync(accountUpdate);
//             return Unit.Value;
//         }
//     }
// }
