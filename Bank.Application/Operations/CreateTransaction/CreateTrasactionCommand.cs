using MediatR;

namespace Bank.Application.Transactions.CreateTransaction
{
    public record CreateTransactionCommand : IRequest<CreateTransactionResponse>
    {
        public int Sum { get; init; }
        public string CardNumber { get; init; }
    }
}
