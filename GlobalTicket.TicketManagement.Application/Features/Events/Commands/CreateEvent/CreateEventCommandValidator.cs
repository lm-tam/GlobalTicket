using FluentValidation;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
        
        RuleFor(n => n.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(n => n.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTimeOffset.Now);

        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");
        
        RuleFor(n => n.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0);
    }

    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
    {
        return !(await _eventRepository.IsEventNameAndDateUniqueAsync(e.Name, e.Date));
    }
}