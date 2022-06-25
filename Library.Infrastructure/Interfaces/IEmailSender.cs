using Library.Core.Models.Dtos.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Interfaces
{
    public interface IEmailSender
    {
        Task EmailSendAsync(EmailParametersDto emailParameters);
    }
}
