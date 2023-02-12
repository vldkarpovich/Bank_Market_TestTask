using Bank.EFModels.Models.Enums;

namespace Bank.DAL.Views;
    public record CreateTransactionResponseView(Guid Id, TransactionStatus TransactionStatus);
