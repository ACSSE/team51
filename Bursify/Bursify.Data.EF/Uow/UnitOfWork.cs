using System;
using System.Data;
using System.Data.Entity;

namespace Bursify.Data.EF.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextTransaction transaction;
        private bool comitted;
        private bool rolledBack;
        private bool disposed;

        public DataContext Context { get; private set; }

        public UnitOfWork(DataContext context)
        {
            Context = context;
            transaction = Context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            try
            {
                this.Context.SaveChanges();

                this.transaction.Commit();
            }
            catch(Exception e)
            {
                this.Rollback();
                throw;
            }

            this.comitted = true;
        }

        public void Rollback()
        {
            this.transaction.Rollback();

            this.Context.Dispose();

            this.rolledBack = true;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
