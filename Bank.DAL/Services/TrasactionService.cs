using AutoMapper;
using Bank.DAL.Interfaces.Repositories;
using Bank.DAL.Interfaces.Services;
using Bank.DAL.Views;
using Bank.EFModels;
using Bank.EFModels.Models;
using Bank.EFModels.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.DAL.Services
{
    public class TransactionService : ITransactionSerice
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper, IServiceProvider serviceProvider)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async Task<GetTransactionResponseView> GetTransactionById(Guid id)
        {
            var result = await _transactionRepository.GetByIdAsync(id);

            return _mapper.Map<GetTransactionResponseView>(result);
        }

        public async Task<CreateTransactionResponseView> CreateTransaction(CreateTransactionRequestView request)
        {
            var transaction = _mapper.Map<Transaction>(request);
            transaction.Id = Guid.NewGuid();
            transaction.TransactionStatus = TransactionStatus.InProcess;
            transaction.CreatedDate = DateTime.Now;

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();

            ChangeTransactionStatus(transaction);

            return _mapper.Map<CreateTransactionResponseView>(transaction);
        }

        public async Task ChangeTransactionStatus(Transaction transaction)
        {
            var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ITransactionRepository>();

            await Task.Delay(5000);
            
            if (transaction.Sum >= 1000)
                transaction.TransactionStatus = TransactionStatus.Accept;
            else
                transaction.TransactionStatus = TransactionStatus.Fail;

            await db.UpdateTransactionStatus(transaction);
        }
    }
}
