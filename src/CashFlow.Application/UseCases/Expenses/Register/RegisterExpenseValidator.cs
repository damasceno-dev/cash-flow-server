using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseValidator :AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {

    }
}