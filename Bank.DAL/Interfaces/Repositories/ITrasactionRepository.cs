using Bank.DAL.Contracts;
using Bank.EFModels.Models.Transactions;

namespace Bank.DAL.Interfaces.Repositories
{
    /// <summary>
    /// Repository for work with ef transactions object
    /// </summary>
    public interface ITransactionRepository : IBaseKeyRepository<Transaction>
    {
        /// <summary>
        /// Update transaction status method
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns> Transaction with changed status </returns>
        public Task<Transaction> UpdateTransactionStatus(Transaction transaction);
    }
}
