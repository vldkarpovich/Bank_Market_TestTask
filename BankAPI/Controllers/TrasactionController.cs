using Bank.API.Controllers.Base;
using Bank.Application.Transactions.CreateTransaction;
using Bank.Application.Transactions.GetTransactionStatus;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class TransactionController : BaseController
    {
        [HttpGet("get-status")]
        public async Task<ActionResult<GetTransactionStatusResponse>> GetTransactions([FromQuery] Guid id)
        {
            var query = new GetTransactionStatusQuery(id);
            return await Mediator.Send(query);
        }

        [HttpPost("create-order")]
        public async Task<ActionResult<CreateTransactionResponse>> CreateOrder(CreateTransactionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}