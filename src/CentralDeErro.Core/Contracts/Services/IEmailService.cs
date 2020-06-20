using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
