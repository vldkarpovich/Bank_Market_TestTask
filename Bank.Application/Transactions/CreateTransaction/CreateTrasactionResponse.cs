using Bank.EFModels.Models.Enums;

namespace Bank.Application.Transactions.CreateTransaction;
    public record CreateTransactionResponse(Guid Id,TransactionStatus TransactionStatus);