using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Bursify.Data.EF.Uow
{
    public class DatabaseConfiguration : DbConfiguration
    {
        public DatabaseConfiguration()
        {
            this.SetDatabaseInitializer<DataContext>(null);

            this.SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
        }
    }
}