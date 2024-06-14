using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request); 
        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("The title is required.");
        }
        if (request.Amount <= 0)
        {
            throw new ArgumentException("The Amount must be greater than zero.");
        }
        if (DateTime.Compare(request.Date, DateTime.UtcNow) > 0)
        {
            throw new ArgumentException("Can't save for future dates.");
        }
        if (Enum.IsDefined(typeof(PaymentType), request.PaymentType) == false)
        {
            throw new ArgumentException("The payment type is not valid.");
        }

    }
}