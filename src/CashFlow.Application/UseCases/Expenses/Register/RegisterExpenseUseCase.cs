using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
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
        
        _repository.Add(entity);
        _unitOfWork.Commit();

        //Before dependency injection:
        // reference infra project and import using CashFlow.Infrastructure.DataAccess;
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