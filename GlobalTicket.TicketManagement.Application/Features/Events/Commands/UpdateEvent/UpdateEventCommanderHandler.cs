using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommanderHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;

    private readonly IMapper _mapper;

    public UpdateEventCommanderHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId, cancellationToken);

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

        await _eventRepository.UpdateAsync(eventToUpdate, cancellationToken);
    }
}