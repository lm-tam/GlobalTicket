using MediatR;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.DeleteCommand;

public class DeleteEventCommand : IRequest
{
    public Guid EventId { get; set; }
}