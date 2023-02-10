using Bank.EFModels.Models.Enums;

namespace Bank.Application.Transactions.CreateTransaction
{
    public class CreateTransactionResponse
    {
        public Guid Id { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
