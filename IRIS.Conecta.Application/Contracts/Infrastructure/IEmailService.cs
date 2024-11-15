using IRIS.Conecta.Application.Models.Email;

namespace IRIS.Conecta.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmailAsync(Email email);
    }
}
