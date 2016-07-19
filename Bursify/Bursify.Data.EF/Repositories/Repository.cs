using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class Repository<TEntity> where TEntity : class, IEntity
    {
        public Repository(DataSession dataSession)
        {
            Session = dataSession;
        }

        protected DataContext DbContext
        {
            get { return Session.UnitOfWork.Context; }
        }

        protected ObjectContext ObjectContext
        {
            get { return ((IObjectContextAdapter) DbContext).ObjectContext; }
        }

        public DataSession Session { get; private set; }

        public TEntity LoadById(int id)
        {
            TEntity entity = DbContext.Set<TEntity>().Find(id);

            return entity;
        }

        public List<TEntity> LoadAll()
        {
            List<TEntity> entities = DbContext.Set<TEntity>().ToList();

            return entities;
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

        public void Save(TEntity entity)
        {
            TEntity existing = LoadById(entity.Id);

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

        public void Save(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Save(entity);
            }
        }

        public void Delete(int id)
        {
            TEntity entity = LoadById(id);

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

        protected string GetEntitySetName<T>()
        {
            string entityTypeName = typeof (T).Name;

            EntityContainer container = ObjectContext.MetadataWorkspace
                .GetEntityContainer(ObjectContext.DefaultContainerName, DataSpace.CSpace);

            string entitySetName = (from meta in container.BaseEntitySets
                where meta.ElementType.Name == entityTypeName
                select meta.Name).First();

            return entitySetName;
        }
    }
}