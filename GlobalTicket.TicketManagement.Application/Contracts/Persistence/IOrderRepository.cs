using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size, CancellationToken toke = default);

    Task<int> GetTotalCountOfOrdersForMonth(DateTime date, CancellationToken token = default);
}