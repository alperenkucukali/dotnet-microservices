
using Account.API.GrpcServices;
using Account.Application.Constants.Messages;
using Account.Application.Features.Accounts.Commands.Adding;
using Account.Application.Features.Accounts.Commands.CreateAccount;
using Account.Application.Features.Accounts.Commands.Withdrawing;
using Account.Application.Features.Accounts.Queries.GetAccount;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CustomerGrpcService _customerGrpcService;
        private readonly IPublishEndpoint _publishEndpoint;

        public AccountsController(IMediator mediator, CustomerGrpcService customerGrpcService, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _customerGrpcService = customerGrpcService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateAccountCommand command)
        {
            var checkCustomer = await _customerGrpcService.CheckCustomer(command.CustomerId);
            if (!checkCustomer)
                return NotFound(AccountMessages.CustomerNotFound);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Adding")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Adding([FromBody] AddingCommand command)
        {
            await _mediator.Send(command);
            await _publishEndpoint.Publish(
                new AccountTransactionEvent()
                {
                    CustomerId = command.CustomerId,
                    AccountId = command.AccountId,
                    Amount = command.Amount,
                    Type = TransactionType.Adding
                });
            return Ok();
        }

        [HttpPost("Withdrawing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Withdrawing([FromBody] WithdrawingCommand command)
        {
            await _mediator.Send(command);
            await _publishEndpoint.Publish(
                new AccountTransactionEvent()
                {
                    CustomerId = command.CustomerId,
                    AccountId = command.AccountId,
                    Amount = command.Amount,
                    Type = TransactionType.Withdrawing
                });
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetAccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new AccountQuery { AccountId = id });
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
