using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.GetAll;

public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesJson> Execute();
}