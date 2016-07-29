using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.CampaignUser
{
    class CampaignReports : IEntity
    {
        public int ID { get; }
        public int CamapignId { get; set; }
        public string Reason { get; set; }
        
    }
}
