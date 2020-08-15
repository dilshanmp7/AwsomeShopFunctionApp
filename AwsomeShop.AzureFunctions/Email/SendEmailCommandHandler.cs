using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AwsomeShop.AzureQueueLibrary.Message;

namespace AwsomeShop.AzureFunctions.Email
{
    public class SendEmailCommandHandler : SendEmailCommandHandler.ISendEmailCommandHandler
    {
        private readonly EmailConfig _emailConfig;

        public SendEmailCommandHandler(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task Handle(SendEmailCommand sendEmailCommand)
        {
            var client = new SmtpClient(_emailConfig.Host, _emailConfig.Port)
            {
                Credentials = new NetworkCredential(_emailConfig.Sender, _emailConfig.Password), EnableSsl = true
            };

            var message = new MailMessage(_emailConfig.Sender, sendEmailCommand.To, sendEmailCommand.Subject,
                sendEmailCommand.Body);

            await Task.CompletedTask;
        }

        public interface ISendEmailCommandHandler
        {
            Task Handle(SendEmailCommand sendEmailCommand);
        }
    }
}
