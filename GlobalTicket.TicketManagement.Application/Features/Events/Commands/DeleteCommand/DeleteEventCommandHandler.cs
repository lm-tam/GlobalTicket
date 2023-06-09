using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteCommand;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;

    public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await this._eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        await _eventRepository.DeleteAsync(eventToDelete, cancellationToken);
    }
}