using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public int Price { get; set; }

    public string? Artist { get; set; }

    public DateTimeOffset Date { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public Guid CategoryId { get; set; }

    public override string ToString() => $"Event name: {Name}; Price: {Price}; By {Artist}; On: {Date:d}; Description: {Description}";
}