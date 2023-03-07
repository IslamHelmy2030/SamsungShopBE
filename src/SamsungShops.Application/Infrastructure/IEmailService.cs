using SamsungShops.Application.Models;

namespace SamsungShops.Application.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
