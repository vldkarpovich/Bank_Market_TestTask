using MediatR;

namespace Bank.Application.Transactions.CreateTransaction;
    public record CreateTransactionCommand(double Sum, string CardNumber) : IRequest<CreateTransactionResponse>;
