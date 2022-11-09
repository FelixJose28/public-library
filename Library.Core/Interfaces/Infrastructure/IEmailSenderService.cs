using Library.Core.Dtos.Customs;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.Infrastructure
{
    public interface IEmailSenderService
    {
        Task EmailSendAsync(EmailParametersDto emailParameters);
    }
}
