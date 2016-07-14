using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.UoW
{
    public interface IDbFactory : IDisposable
    {
        BursifyContext Init();
    }
}
