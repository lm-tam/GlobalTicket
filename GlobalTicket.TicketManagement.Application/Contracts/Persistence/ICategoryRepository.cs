using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<List<Category>> GetCategoriesWithEventsAsync(bool includePassedEvents);
}