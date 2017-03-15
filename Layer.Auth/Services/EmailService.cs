using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Layer.Auth.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var confirmationEmail = new MailMessage(ConfigurationManager.AppSettings["emailService:Account"],
                message.Destination, message.Subject, message.Body)
            { Priority = MailPriority.High, IsBodyHtml = true };

            var client = new SmtpClient();
            client.SendCompleted += (sender, args) =>
            {
                client.Dispose();
                confirmationEmail.Dispose();
            };
            return client.SendMailAsync(confirmationEmail);
        }
    }
}
