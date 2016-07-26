using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.SponsorUser;

namespace Bursify.Data.EF.User
{
    public class CampaignSponsor : IBridgeEntity
    {
        public int CampaignId { get; set; }
        public int SponsorId { get; set; }
        public double AmountContributed { get; set; }
        public DateTime DateOfContribution { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Sponsor Sponsor { get; set; }

        public int leftId
        {
            get { return CampaignId; }
        }

        public int rightId
        {
            get { return SponsorId; }
        }
    }
}
