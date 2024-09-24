using Microsoft.AspNetCore.Mvc;
using Transaction.API.Data.DTOs.Requests;
using Transaction.API.Data.DTOs.Responses;
using Transaction.API.Services.Interfaces;

namespace Transaction.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionService transactionService) : ControllerBase
        {
        [HttpGet("{accountId}")]
        [ProducesResponseType(typeof(List<TransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetByAccountId(Guid accountId)
        {
            return Ok(await transactionService.GetByAccountId(accountId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TransactionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetWithFilter([FromQuery]RequestFilter filter)
        {
            return Ok(await transactionService.GetWithFilter(filter));
        }
    }
}
