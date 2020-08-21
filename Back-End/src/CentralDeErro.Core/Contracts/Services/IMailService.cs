using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
