using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagement.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size, CancellationToken token = default)
        {
            return await DbContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync(token);
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date, CancellationToken token = default)
        {
            return await DbContext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year, token);
        }
    }
}
