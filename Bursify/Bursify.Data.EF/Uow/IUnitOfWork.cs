using System;

namespace Bursify.Data.EF.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        DataContext Context { get; }

        void Commit();

        void Rollback();
    }
}
