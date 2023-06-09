using GlobalTicket.TicketManagement.Application.Models;
using GlobalTicket.TicketManagement.Application.Models.Mail;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email, CancellationToken token = default);
}