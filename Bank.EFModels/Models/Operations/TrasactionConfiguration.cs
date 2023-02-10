using Microsoft.EntityFrameworkCore;

namespace Bank.EFModels.Models.Transactions
{
    public static class TransactionConfiguration
    {
        public static void CreateTransactionEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions");
        }
    }
}
