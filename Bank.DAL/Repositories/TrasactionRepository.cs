using Bank.DAL.Interfaces.Repositories;
using Bank.DAL.Repositories.Base;
using Bank.EFModels;
using Bank.EFModels.Models.Transactions;
using Microsoft.Extensions.Logging;


namespace Bank.DAL.Repositories
{
    public class TransactionRepository : BaseKeyRepository<TransactionRepository, Transaction>, ITransactionRepository
    {
        public TransactionRepository(ILogger<TransactionRepository> logger, ApplicationDataContext context)
        : base(logger, context)
        {

        }


        public async Task<Transaction> UpdateTransactionStatus(Transaction transaction)
        {
            try
            {
                if (transaction == null)
                    throw new ArgumentNullException("transaction cannot be null");

                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                return transaction;
            }
            catch (Exception e)
            {
                _logger.LogError("Could not update transaction " + typeof(Transaction).ToString() + ": " + e.ToString());
                throw;
            }
        }
    }
}
