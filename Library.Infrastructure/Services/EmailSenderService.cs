using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Infrastructure.Interfaces;
using MimeKit.Text;
using Microsoft.Extensions.Configuration;
using Library.Core.Models.Dtos.Customs;

namespace Library.Infrastructure.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EmailSendAsync(EmailParametersDto emailParameters)
        {
            var emailConfiguration = GetEmailSendConfiguration();
            var message = GenerateEmailMessage(emailParameters, emailConfiguration.UserName, emailConfiguration.User);
            await SendEmailAsync(emailConfiguration,message);
        }


        private EmailConfiguration GetEmailSendConfiguration()
        {
            var emailConfiguration = new EmailConfiguration
            {
                Host = _configuration.GetValue<string>("EmailConfiguration:Host"),
                Port = _configuration.GetValue<int>("EmailConfiguration:Port"),
                User = _configuration.GetValue<string>("EmailConfiguration:User"),
                UserName = _configuration.GetValue<string>("EmailConfiguration:UserName"),
                Password = _configuration.GetValue<string>("EmailConfiguration:Password")
            };
            var emailProp =  emailConfiguration.GetType().GetProperties();
            foreach (var item in emailProp)
            {
                if (item.GetValue(emailConfiguration) is null) throw new ArgumentNullException($"{item.Name} property can't no be null");
            }
            return emailConfiguration;
        }

        private MimeMessage GenerateEmailMessage(EmailParametersDto emailParameters, string userSenderName, string userSender)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(userSenderName, userSender));
            message.To.Add(new MailboxAddress(emailParameters.ToName, emailParameters.ToEmail));
            message.Subject = emailParameters.Subject;
            message.Body = new TextPart(emailParameters.IsHtml ? TextFormat.Html : TextFormat.Plain)
            {
                Text = emailParameters.MessageText
            };
            return message;
        }

        private async Task SendEmailAsync(EmailConfiguration emailConfiguration, MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(
                    emailConfiguration.Host,
                    emailConfiguration.Port, 
                    MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(emailConfiguration.User, emailConfiguration.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        private class EmailConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public string User { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
