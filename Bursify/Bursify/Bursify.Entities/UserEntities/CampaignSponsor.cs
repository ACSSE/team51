using Bursify.Entities.CampaignEntities;
using Bursify.Entities.SponsorEntities;
using System;

namespace Bursify.Entities.UserEntities
{
    public class CampaignSponsor
    {
        public int CampaignId { get; set; }
        public int SponsorId { get; set; }
        public double AmountContributed { get; set; }
        public DateTime DateOfContribution { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
