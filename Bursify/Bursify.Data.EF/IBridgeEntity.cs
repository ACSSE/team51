using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF
{
    public interface IBridgeEntity
    {
        int leftId { get; }
        int rightId { get; }
    }
}
