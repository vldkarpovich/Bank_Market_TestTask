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


        public async Task<Transaction> UpdateTransactionByIdAsync(Transaction transaction)
        {
            try
            {
                //var transaction = _context.Transactions.First(c => c.Id == id);

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

        //public async Task<Transaction> GetByCardNumberAsync(string cardNumber)
        //{
        //    try
        //    {
        //        if (cardNumber == null)
        //            throw new ArgumentNullException("Credit card number for input can not be null");

        //        return await _context.Transactions.FindAsync(cardNumber);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("Could not fetch by id for set " + typeof(Transaction).ToString() + ": " + e.ToString());
        //        throw;
        //    }
        //}
    }
}
