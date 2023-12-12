using MailKit.Net.Smtp;
using MimeKit;
using Is_Sistem.Application.Common.Email;
using Microsoft.Extensions.Logging;

namespace Is_Sistem.Application.Services.Impl;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly SmtpSettings _smtpSettings;

    public EmailService(SmtpSettings smtpSettings, ILogger<EmailService> logger)
    {
        _logger = logger;
        _smtpSettings = smtpSettings;
    }


    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        await Task.Delay(100);

        _logger.LogInformation($"Email was sent to: [{emailMessage.ToAddress}]. Body: {emailMessage.Body}");
        //await SendAsync(CreateEmail(emailMessage));
    }

    private async Task SendAsync(MimeMessage message)
    {
        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

            await client.SendAsync(message);
        }
        catch
        {
            await client.DisconnectAsync(true);
            client.Dispose();

            throw;
        }
    }

    private MimeMessage CreateEmail(EmailMessage emailMessage)
    {
        var builder = new BodyBuilder { HtmlBody = emailMessage.Body };

        if (emailMessage.Attachments.Count > 0)
            foreach (var attachment in emailMessage.Attachments)
                builder.Attachments.Add(attachment.Name, attachment.Value);

        var email = new MimeMessage
        {
            Subject = emailMessage.Subject,
            Body = builder.ToMessageBody()
        };

        email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
        email.To.Add(new MailboxAddress(emailMessage.ToAddress.Split("@")[0], emailMessage.ToAddress));

        return email;
    }
}
