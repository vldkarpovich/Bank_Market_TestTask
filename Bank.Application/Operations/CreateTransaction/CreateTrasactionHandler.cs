﻿using AutoMapper;
using Bank.DAL.Interfaces.Repositories;
using Bank.DAL.Interfaces.Services;
using Bank.DAL.Views;
using Bank.EFModels.Models.Enums;
using Bank.EFModels.Models.Transactions;
using MediatR;

namespace Bank.Application.Transactions.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
    {
        private readonly ITransactionSerice _transactionService;
        private readonly IMapper _mapper;

        public CreateTransactionHandler(ITransactionSerice transactionService, IMapper mapper) 
        { 
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionService.CreateTransaction(_mapper.Map<CreateTransactionRequestView>(request));

            if (result == null)
            {
                //throw new RestException(HttpStatusCode.NotFound);
            }

            return _mapper.Map<CreateTransactionResponse>(result);
        }
    }
}
