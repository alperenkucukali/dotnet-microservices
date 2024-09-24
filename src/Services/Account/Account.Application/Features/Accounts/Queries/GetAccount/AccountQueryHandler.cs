// using Account.Application.Contracts.Persistence;
// using Account.Application.Exceptions;
// using AutoMapper;
// using MediatR;
// using Microsoft.Extensions.Logging;
//
// namespace Account.Application.Features.Accounts.Queries.GetAccount
// {
//     public class AccountQueryHandler(
//         IAccountRepository accountRepository,
//         IMapper mapper,
//         ILogger<AccountQueryHandler> logger)
//         : IRequestHandler<AccountQuery, GetAccountResponse>
//         {
//         private readonly ILogger<AccountQueryHandler> _logger = logger;
//
//         public async Task<GetAccountResponse> Handle(AccountQuery request, CancellationToken cancellationToken)
//         {
//             var account = await accountRepository.GetAsync(x => x.Id == request.AccountId && x.CustomerId == request.CustomerId);
//             if (account is null)
//                 throw new NotFoundException(nameof(Domain.Entities.Account), request.AccountId);
//             if (account.CustomerId != request.AccountId)
//                 throw new UnauthorizedAccessException();
//             return mapper.Map<GetAccountResponse>(account)!;
//         }
//     }
// }
