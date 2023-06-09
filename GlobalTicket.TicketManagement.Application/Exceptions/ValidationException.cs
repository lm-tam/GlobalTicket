using FluentValidation.Results;

namespace GlobalTicket.TicketManagement.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }

    public ValidationException(string message) : base(message)
    {
        
    }

    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = new List<string>();
        ValidationErrors = validationResult.Errors.Select(n => n.ErrorMessage).ToList();
    }
}