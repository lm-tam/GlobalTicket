namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventList;

public class EventListVm
{
    public Guid EventId { get; set; }

    public string Name { get; set; }

    public DateTimeOffset Date { get; set; }

    public string ImageUrl { get; set; }
}