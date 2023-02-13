using Bank.EFModels.Models.Base;
using Bank.EFModels.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.EFModels.Models
{
    [Table("Transactions")]
    public class Transaction : Entity
    {
        public string CardNumber { get; set; }
        public double Sum { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
}
