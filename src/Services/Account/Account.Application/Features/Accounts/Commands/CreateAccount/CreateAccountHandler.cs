// using Account.Application.Contracts.Persistence;
// using AutoMapper;
// using MediatR;
// using Microsoft.Extensions.Logging;
//
// namespace Account.Application.Features.Accounts.Commands.CreateAccount
// {
//     public class CreateAccountHandler(
//         IAccountRepository accountRepository,
//         IMapper mapper,
//         ILogger<CreateAccountHandler> logger)
//         : IRequestHandler<CreateAccountCommand, Guid>
//         {
//         private readonly ILogger<CreateAccountHandler> _logger = logger;
//
//         public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
//         {
//             var accountEntity = mapper.Map<Domain.Entities.Account>(request);
//             var newAccount = await accountRepository.AddAsync(accountEntity!);
//             return newAccount.Id;
//         }
//     }
// }
