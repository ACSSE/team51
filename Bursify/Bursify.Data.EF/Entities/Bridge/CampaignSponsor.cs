using System;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.Entities.Bridge
{
    public class CampaignSponsor : IBridgeEntity
    {
        //public int ID { get; set; }
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
