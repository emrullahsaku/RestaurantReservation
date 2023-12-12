using Is_Sistem.Application.Common.Email;

namespace Is_Sistem.Application.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailMessage emailMessage);
}
