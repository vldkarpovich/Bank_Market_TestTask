﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Transactions.GetTransactionStatus;
    public record GetTransactionStatusQuery(Guid id) : IRequest<GetTransactionStatusResponse>;
