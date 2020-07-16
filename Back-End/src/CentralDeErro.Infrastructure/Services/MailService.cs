using CentralDeErro.Core.Contracts.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace CentralDeErro.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            try
            {
                var apiKey = _configuration["MailServiceKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_configuration["MailServiceFrom"], "JarvisLog");
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
                await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
