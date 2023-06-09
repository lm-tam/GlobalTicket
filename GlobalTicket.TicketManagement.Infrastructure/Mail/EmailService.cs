using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GlobalTicket.TicketManagement.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public EmailSettings _emailSettings { get; }

    public EmailService(IOptions<EmailSettings> mailSettings)
    {
        _emailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmailAsync(Email email, CancellationToken token = default)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);

        var subject = email.Subject;
        var to = new EmailAddress(email.To);
        var emailBody = email.Body;

        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        
        var response = await client.SendEmailAsync(sendGridMessage, token);
        
        return response.StatusCode is System.Net.HttpStatusCode.Accepted or System.Net.HttpStatusCode.OK;
    }
}