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
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EmailSendAsync(EmailParametersDto emailParameters)
        {
            //string messageText, string to,string html
            string host = _configuration.GetValue<string>("EmailConfiguration:Host");
            int port = _configuration.GetValue<int>("EmailConfiguration:Port");
            string user = _configuration.GetValue<string>("EmailConfiguration:User");
            string pass = _configuration.GetValue<string>("EmailConfiguration:Password");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Felix Jose", user));
            message.To.Add(new MailboxAddress(emailParameters.ToName, emailParameters.ToEmail));
            message.Subject = emailParameters.Subject;
            message.Body = new TextPart(emailParameters.IsHtml ? TextFormat.Html : TextFormat.Plain)
            {
                Text = emailParameters.MessageText
            };


            using (var client = new SmtpClient())
            {
                // Note: only needed if the SMTP server requires authentication
                await client.ConnectAsync(host, port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(user, pass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
