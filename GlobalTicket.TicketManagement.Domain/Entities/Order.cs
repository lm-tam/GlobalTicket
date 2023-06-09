using GlobalTicket.TicketManagement.Domain.Common;

namespace GlobalTicket.TicketManagement.Domain.Entities;

public class Order : AuditableEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int OrderTotal { get; set; }

    public DateTimeOffset OrderPlaced { get; set; }

    public bool OrderPaid { get; set; }
}