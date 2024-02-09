using Account.Application.Contracts.Persistence;
using Account.Application.Features.Accounts.Queries.GetAccount;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAccountHandler> _logger;

        public CreateAccountHandler(IAccountRepository AccountRepository, IMapper mapper, ILogger<CreateAccountHandler> logger)
        {
            _accountRepository = AccountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountEntity = _mapper.Map<Domain.Entities.Account>(request);
            var newAccount = await _accountRepository.AddAsync(accountEntity!);
            return newAccount.Id;
        }
    }
}
