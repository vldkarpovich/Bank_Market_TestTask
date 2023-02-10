using Bank.DAL.Contracts;
using Bank.EFModels.Models.Transactions;

namespace Bank.DAL.Interfaces.Repositories
{
    public interface ITransactionRepository : IBaseKeyRepository<Transaction>
    {
        public Task<Transaction> UpdateTransactionByIdAsync(Transaction transaction);
        //public Task<Transaction> GetByCardNumberAsync(string cardNumber);
    }
}
