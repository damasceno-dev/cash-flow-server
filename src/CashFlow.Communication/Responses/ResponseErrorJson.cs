namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = new List<string>() { errorMessage };
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        
        ErrorMessages = errorMessages;
    }
    public List<string> ErrorMessages { get; set; }
   
    
}