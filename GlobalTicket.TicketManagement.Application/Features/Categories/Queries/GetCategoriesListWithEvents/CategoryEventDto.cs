namespace GlobalTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class CategoryEventDto
{
    public Guid EventId { get; set; }

    public string Name { get; set; }

    public int Price { get; set; }

    public string? Artist { get; set; }

    public DateTimeOffset Date { get; set; }

    public Guid CategoryId { get; set; }
}