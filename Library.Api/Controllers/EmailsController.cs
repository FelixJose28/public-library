using Library.Core.Models.Dtos.Customs;
using Library.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task SendEmail(EmailParametersDto emailParameters)
        {
            await _emailSender.EmailSendAsync(emailParameters);
        }
    }
}
