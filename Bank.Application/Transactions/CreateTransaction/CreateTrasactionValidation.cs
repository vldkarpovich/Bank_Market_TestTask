﻿using FluentValidation;

namespace Bank.Application.Transactions.CreateTransaction
{
    /// <summary>
    /// Credit cad validation rule
    /// </summary>
    public class CreateTransactionValidation : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionValidation() 
        {
            RuleFor(x => x.CardNumber).MaximumLength(16).WithMessage("Credit card number is too long");

            RuleFor(x => x.CardNumber).NotEmpty().Matches(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$");
        }
    }
}
