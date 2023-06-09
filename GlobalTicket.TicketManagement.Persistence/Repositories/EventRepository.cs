using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTimeOffset date)
        {
            return await DbContext.Events.AnyAsync(e => e.Name.Equals(name) && e.Date.Date.Equals(date.Date));
        }
    }
}
