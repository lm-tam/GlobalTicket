using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;
using ValidationException = GlobalTicket.TicketManagement.Application.Exceptions.ValidationException;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommanderHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;

    private readonly IMapper _mapper;
    
    private readonly IEmailService _emailService;

    public CreateEventCommanderHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<Event>(request);

        var validator = new CreateEventCommandValidator(_eventRepository);

        var validationResult = await validator.ValidateAsync(@request, cancellationToken);
        if (validationResult != null && validationResult.Errors.Any())
        {
            throw new ValidationException(validationResult);
        }

        @event = await _eventRepository.AddAsync(@event, cancellationToken);
        
        //Sending email notification to admin address
        var email = new Email() { To = "gill@snowball.be", Body = $"A new event was created: {request}", Subject = "A new event was created" };

        try
        {
            await _emailService.SendEmailAsync(email, cancellationToken);
        }
        catch (Exception ex)
        {
            //this shouldn't stop the API from doing else so this can be logged
        }

        return @event.EventId;
    }
}