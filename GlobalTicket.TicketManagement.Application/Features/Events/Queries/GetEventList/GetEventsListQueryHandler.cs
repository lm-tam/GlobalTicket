using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;

public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IAsyncRepository<Event> _eventRepository;

    private readonly IMapper _mapper;

    public GetEventsListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _eventRepository.ListAllAsync(cancellationToken)).OrderBy(x => x.Date);

        return _mapper.Map<List<EventListVm>>(allEvents);
    }
}