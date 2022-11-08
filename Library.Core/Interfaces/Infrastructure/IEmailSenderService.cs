using Library.Core.Dtos.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Infrastructure
{
    public interface IEmailSenderService
    {
        Task EmailSendAsync(EmailParametersDto emailParameters);
    }
}
