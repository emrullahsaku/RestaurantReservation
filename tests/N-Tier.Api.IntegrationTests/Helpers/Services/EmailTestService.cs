using System.Threading.Tasks;
using Is_Sistem.Application.Common.Email;
using Is_Sistem.Application.Services;

namespace Is_Sistem.Api.IntegrationTests.Helpers.Services;

public class EmailTestService : IEmailService
{
    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        await Task.Delay(100);
    }
}
