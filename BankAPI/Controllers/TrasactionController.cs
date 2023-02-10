using Bank.API.Controllers.Base;
using Bank.Application.Transactions.CreateTransaction;
using Bank.Application.Transactions.GetTransactionStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class TransactionController : BaseController
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-status")]
        public async Task<ActionResult<GetTransactionStatusResponse>> GetTransactions([FromQuery] Guid id)
        {
            var query = new GetTransactionStatusCommand(id);
            return await Mediator.Send(query);
        }

        [HttpPost("create-order")]
        public async Task<ActionResult<CreateTransactionResponse>> CreateOrder(CreateTransactionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}