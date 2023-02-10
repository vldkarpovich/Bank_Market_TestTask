
using FluentValidation;

namespace Bank.Application.Transactions.CreateTransaction
{
    public class CreateTransactionValidation : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionValidation() 
        {
            RuleFor(x => x.CardNumber).MaximumLength(16).WithMessage("Credit card numbre is too long");

            RuleFor(x => x.CardNumber).NotEmpty().Matches(@"^4[0-9]{12}(?:[0-9]{3})?$)|(^(?:5[1-5][0-9]{2}|222[1-9]
                                                                |22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$)
                                                                |(3[47][0-9]{13})|(^3(?:0[0-5]|[68][0-9])[0-9]{11}$)
                                                                |(^6(?:011|5[0-9]{2})[0-9]{12}$)|(^(?:2131|1800
                                                                |35\d{3})\d{11}$")
                .WithMessage("Wrong symbols in credit card number");
        }
    }
}
