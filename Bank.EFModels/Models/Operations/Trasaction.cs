using Bank.EFModels.Models.Base;
using Bank.EFModels.Models.Enums;

namespace Bank.EFModels.Models.Transactions
{
    public class Transaction : Entity
    {
        public string CardNumber { get; set; }
        public int Sum { get; set; }
        public TransactionStatus? TransactionStatus { get; set; }
    }
}
