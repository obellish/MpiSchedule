using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MpiSchedule.Services;

internal sealed class GmailEmailSender : IEmailSender
{
    private readonly ILogger logger;

    public GmailEmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<GmailEmailSender> logger)
    {
        Options = optionsAccessor.Value;
        this.logger = logger;
    }

    public AuthMessageSenderOptions Options { get; }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        using var client = new SmtpClient(Options.EmailServerAddress, Options.Port);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential(Options.Email, Options.Password);
        client.UseDefaultCredentials = false;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        var mailMessage = new MailMessage(Options.Email!, email, subject, htmlMessage)
        {
            IsBodyHtml = true,
        };

        try
        {
            await client.SendMailAsync(mailMessage);
            logger.LogInformation("Email to {Email} queued successfully", email);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Email to {Email} failed", email);
        }
    }
}