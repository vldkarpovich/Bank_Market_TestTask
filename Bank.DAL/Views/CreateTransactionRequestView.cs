
namespace Bank.DAL.Views
{
    public record CreateTransactionRequestView
    {
        public int Sum { get; init; }
        public string CardNumber { get; init; }
    }
}
