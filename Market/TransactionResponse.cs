namespace Market
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
    }
    public enum TransactionStatus : int { InProces = 1, Accept = 2, Fail = 3 }
}
