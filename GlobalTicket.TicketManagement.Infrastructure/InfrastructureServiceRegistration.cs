using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using GlobalTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagement.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        service.AddTransient<IEmailService, EmailService>();

        return service;
    }
}