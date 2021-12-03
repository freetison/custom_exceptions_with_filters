using custom_exceptions_with_filters.Models;
using FluentValidation;

namespace custom_exceptions_with_filters.Validators
{
    public class CreatePaymentValidator : AbstractValidator<Payment>
    {
        const string RULE_SET = "Payment-Error";

        public CreatePaymentValidator()
        {
            RuleFor(q => q.BankNamne)
               .NotNull().WithErrorCode(RULE_SET).WithMessage(e => "BankNamne is Required")
               .NotEmpty().WithErrorCode(RULE_SET).WithMessage(e => "BankNamne should not be empty");

            RuleFor(q => q.PaymentMethod)
                .NotNull().WithErrorCode(RULE_SET).WithMessage(e => "PaymentMethod is Required")
                .NotEmpty().WithErrorCode(RULE_SET).WithMessage(e => "PaymentMethod should not be empty");

            RuleFor(q => q.Amount)
                .NotNull().WithErrorCode(RULE_SET).WithMessage(e => "Amount is Required")
                .NotEmpty().WithErrorCode(RULE_SET).WithMessage(e => "Amount should not be empty")
                .GreaterThan(0).WithErrorCode(RULE_SET).WithMessage(e => "Amount must be greater than zero");

        }

    }
}
