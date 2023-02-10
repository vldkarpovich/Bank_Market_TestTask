using AutoMapper;
using Bank.Application.Transactions.GetTransactionStatus;
using Bank.DAL.Interfaces.Services;
using MediatR;

namespace Bank.Application.Operations.GetOperationStatus
{
    internal class GetTransactionStatusHandler : IRequestHandler<GetTransactionStatusCommand, GetTransactionStatusResponse>
    {
        private readonly ITransactionSerice _transactionService;
        private readonly IMapper _mapper;

        public GetTransactionStatusHandler(ITransactionSerice transactionService, IMapper mapper) 
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<GetTransactionStatusResponse> Handle(GetTransactionStatusCommand request, CancellationToken cancellationToken)
        {
            var result = await _transactionService.GetTransactionById(request.id);

            return _mapper.Map<GetTransactionStatusResponse>(result); ;
        }
    }
}
