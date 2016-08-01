using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.CampaignUser
{
    public class CampaignReport : IBridgeEntity
    {
        public int CampaignId { get; set; }
        public int BursifyUserId { get; set; }
        public string Reason { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }
        public virtual Campaign Campaign { get; set; }

        public int leftId
        {
            get { return CampaignId; }
        }

        public int rightId
        {
            get { return BursifyUserId; }
        }
    }
}
