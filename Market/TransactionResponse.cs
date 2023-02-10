using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
    public enum TransactionStatus : int { InProces = 1, Accept = 2, Fail = 3 }
}
