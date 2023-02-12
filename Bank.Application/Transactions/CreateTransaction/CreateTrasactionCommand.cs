using MediatR;

namespace Bank.Application.Transactions.CreateTransaction;
    public record CreateTransactionCommand(int Sum, string CardNumber) : IRequest<CreateTransactionResponse>;
