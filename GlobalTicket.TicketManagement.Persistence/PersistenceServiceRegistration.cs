using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GlobalTicketDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("GlobalTicketTicketManagementConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}