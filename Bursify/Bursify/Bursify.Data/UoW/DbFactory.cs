using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.UoW
{
    public class DbFactory : Disposable, IDbFactory
    {
        BursifyContext dbContext;

        public BursifyContext Init()
        {
            return dbContext ?? (dbContext = new BursifyContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
