using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Bursify.EntityFramework.Repositories
{
    public abstract class BursifyRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BursifyDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BursifyRepositoryBase(IDbContextProvider<BursifyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class BursifyRepositoryBase<TEntity> : BursifyRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BursifyRepositoryBase(IDbContextProvider<BursifyDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
