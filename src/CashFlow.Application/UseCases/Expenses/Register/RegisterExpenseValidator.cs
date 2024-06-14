using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator :AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(e => e.Title).NotEmpty().WithMessage("The title is required.");
        RuleFor(e => e.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero.");
        RuleFor(e => e.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Can't save for future dates.");
        RuleFor(e => e.PaymentType).IsInEnum().WithMessage("The payment type is not valid.");
    }
}