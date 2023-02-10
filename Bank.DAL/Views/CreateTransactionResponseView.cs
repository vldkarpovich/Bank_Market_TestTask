using Bank.EFModels.Models.Enums;

namespace Bank.DAL.Views
{
    public record CreateTransactionResponseView
    {
        public Guid Id { get; init; }
        public TransactionStatus TransactionStatus { get; init; }
    }
}
