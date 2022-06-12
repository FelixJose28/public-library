using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository _bookRepository { get; }
        void Commit();
        Task CommitAsync();
    }
}
