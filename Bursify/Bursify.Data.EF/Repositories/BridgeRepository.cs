using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Bursify.Data.EF.Uow;

//not sure if works but used to handle bridging table queries
namespace Bursify.Data.EF.Repositories
{
    public class BridgeRepository<TEntity> where TEntity : class, IBridgeEntity
    {
        public DataSession Session { get; private set; }

        public BridgeRepository(DataSession dataSession)
        {
            Session = dataSession;
        }

        protected DataContext DbContext
        {
            get { return Session.UnitOfWork.Context; }
        }

        protected ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter)DbContext).ObjectContext; }
        }

        public void Save(TEntity entity)
        {
            TEntity existing = LoadByIds(entity.leftId, entity.rightId);

            if (existing == null)
            {
                DbContext.Set<TEntity>().Add(entity);
            }
            else
            {
                string entitySetName = GetEntitySetName<TEntity>();
                ObjectContext.ApplyCurrentValues(entitySetName, entity);
            }

            ObjectContext.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        }

        public TEntity LoadByIds(int leftId, int rightId)
        {
            TEntity entity = DbContext.Set<TEntity>().Find(leftId, rightId);
            return entity;
        }

        public void Save(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Save(entity);
            }
        }

        public void Delete(int leftId, int rightId)
        {
            TEntity entity = LoadByIds(leftId, rightId);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Delete(entity);
            }
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = DbContext.Set<TEntity>().FirstOrDefault(predicate);

            return entity;
        }

        public List<TEntity> FindMany(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = DbContext.Set<TEntity>().Where(predicate).ToList();

            return entities;
        }

        public List<TEntity> LoadAll()
        {
            var entities = DbContext.Set<TEntity>().ToList();

            return entities;
        }

        protected string GetEntitySetName<T>()
        {
            string entityTypeName = typeof(T).Name;

            EntityContainer container = ObjectContext.MetadataWorkspace.GetEntityContainer(ObjectContext.DefaultContainerName, DataSpace.CSpace);

            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return entitySetName;
        }
    }
}
