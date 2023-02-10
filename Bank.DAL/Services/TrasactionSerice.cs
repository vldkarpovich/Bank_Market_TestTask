using AutoMapper;
using Bank.DAL.Interfaces.Repositories;
using Bank.DAL.Interfaces.Services;
using Bank.DAL.Views;
using Bank.EFModels.Models.Enums;
using Bank.EFModels.Models.Transactions;

namespace Bank.DAL.Services
{
    public class TransactionSerice : ITransactionSerice
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionSerice(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository= transactionRepository;
            _mapper = mapper;
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
            transaction.TransactionStatus = TransactionStatus.InProces;
            transaction.CreatedDate = DateTime.Now;

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();

            //ChangeTransactionStatus(transaction);

            return _mapper.Map<CreateTransactionResponseView>(transaction);
        }

        public async void ChangeTransactionStatus(Transaction transaction)
        {
            await Task.Delay(10000);
            if (transaction.Sum >= 1000)
                transaction.TransactionStatus = TransactionStatus.Accept;
            else
                transaction.TransactionStatus = TransactionStatus.Fail;

            await _transactionRepository.UpdateTransactionByIdAsync(transaction);

            //await Task.WhenAny(
            //_orderRepository.UpdateTransactionByIdAsync(transaction),
            //Task.Delay(TimeSpan.FromSeconds(10)));

            //Task task = Task.Run(() =>
            //{
            //    var biba = new Transaction { Id = id, CardNumber = transaction.CardNumber, 
            //        Sum = transaction.Sum, TransactionStatus = transaction.TransactionStatus, 
            //        CreatedDate = transaction.CreatedDate };

            //    if (biba.Sum >= 1000)
            //        transaction.TransactionStatus = TransactionStatus.Accept;
            //    else
            //        transaction.TransactionStatus = TransactionStatus.Fail;

            //    Thread.Sleep(10000);     // задержка на 4 секунды - имитация долгой работы

            //    _orderRepository.Update(transaction);
            //    _orderRepository.SaveChangesAsync();
            //});
            //task.Wait();
        }
    }
}
