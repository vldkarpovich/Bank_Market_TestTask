using AutoMapper;
using Bank.Application.Transactions.CreateTransaction;
using Bank.Application.Transactions.GetTransactionStatus;
using Bank.DAL.Views;
using Bank.EFModels.Models;

namespace Bank.Application
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateTransactionRequestView, Transaction>();
            CreateMap<Transaction, CreateTransactionResponseView>();
            CreateMap<CreateTransactionResponseView, CreateTransactionResponse>();
            CreateMap<CreateTransactionCommand, CreateTransactionRequestView>();
            CreateMap<Transaction, GetTransactionResponseView>();
            CreateMap<GetTransactionResponseView, GetTransactionStatusResponse>();
        }
    }
}
