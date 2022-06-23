using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAlertRepository _alertRepository { get; }
        public IAuthorRepository _authorReporitory { get; }
        public IBookRepository _bookRepository { get; }
        public IBookImgRepository _bookImgRepository { get; }
        public IUserRepository _userRepository { get; }
        public ILoginRepository _loginRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
