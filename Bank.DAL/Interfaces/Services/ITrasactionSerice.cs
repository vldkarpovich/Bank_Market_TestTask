using Bank.DAL.Views;
using Bank.EFModels.Models.Transactions;

namespace Bank.DAL.Interfaces.Services
{
    /// <summary>
    /// Transaction service
    /// </summary>
    public interface ITransactionSerice
    {
        public Task<GetTransactionResponseView> GetTransactionById(Guid id);
        public Task<CreateTransactionResponseView> CreateTransaction(CreateTransactionRequestView request);
        public Task ChangeTransactionStatus(Transaction transaction);
        
    }
}
