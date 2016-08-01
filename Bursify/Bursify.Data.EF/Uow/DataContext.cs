using System;
using System.Data.Common;
using System.Data.Entity;
using System.Reflection;
using Bursify.Data.EF.EntityMappings;

namespace Bursify.Data.EF.Uow
{
    [DbConfigurationType(typeof(DatabaseConfiguration))]
    public class DataContext : DbContext
    {
        private const string defaultProvider = "System.Data.SqlClient";

        public DataContext() : base("BursifyDB")
        {
            Database.SetInitializer<DataContext>(null);
        }

        protected DataContext(DbConnection connection)
            : base(connection.ConnectionString)
        {
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddDBModelConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public static DataContext Create(string connectionString)
        {
            return Create(connectionString, defaultProvider);
        }

        public static DataContext Create(string connectionString, string providerInvariantName)
        {
            DbConnection connection = CreateConnection(connectionString, providerInvariantName);
            DataContext context = new DataContext(connection);

            return context;
        }

        private static DbConnection CreateConnection(string connectionString, string providerInvariantName)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerInvariantName);
            DbConnection connection = factory.CreateConnection();

            if (connection != null)
            {
                connection.ConnectionString = connectionString;
            }

            return connection;
        }

        private void AddDBModelConfigurations(DbModelBuilder modelBuilder)
        {
            Type mappingType = typeof(BursifyUserMapping);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(mappingType));
            
        }
    }
}
