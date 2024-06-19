using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionBase;


namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        var entity = new Expense
        {
            Title = request.Title,
            Description = request.Description,
            Date = request.Date,
            Amount = request.Amount,
            PaymentType = request.PaymentType
        };

        //Antes da injeção de dependência:
        // referenciar o projeto de infra e using CashFlow.Infrastructure.DataAccess;
        // var dbContext = new CashFlowDbContext();
        // dbContext.Expenses.Add(entity);
        // dbContext.SaveChanges();
        
        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            List<string> errorList = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorList);
        }
    }
}