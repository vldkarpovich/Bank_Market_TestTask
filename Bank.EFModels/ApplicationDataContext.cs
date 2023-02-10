using Bank.EFModels.Models.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Bank.EFModels
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
           : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreateTransactionEntity();
        }
    }
}