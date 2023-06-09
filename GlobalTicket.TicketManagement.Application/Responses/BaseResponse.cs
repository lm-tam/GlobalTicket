namespace GlobalTicket.TicketManagement.Application.Responses;

public class BaseResponse
{
    public BaseResponse()
    {
        IsSuccess = true;
    }

    public BaseResponse(string message)
    {
        IsSuccess = true;
        Message = message;
    }
    
    public BaseResponse(string message, bool isSuccess)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<string>? ValidationErrors { get; set; }
}