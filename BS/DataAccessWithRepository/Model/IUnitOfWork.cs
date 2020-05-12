using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessWithRepository.Model.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        int Complete();
    }
}
