﻿using Library.Core.Dtos.Customs;
using Library.Core.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailSenderService _emailSender;

        public EmailsController(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task SendEmailAsync(EmailParametersDto emailParameters)
        {
            await _emailSender.EmailSendAsync(emailParameters);
        }
    }
}
