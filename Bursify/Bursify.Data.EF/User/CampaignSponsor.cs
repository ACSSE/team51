﻿using System;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.SponsorUser;

namespace Bursify.Data.EF.User
{
    public class CampaignSponsor : IEntity
    {
        public int ID { get; set; }
        public int CampaignId { get; set; }
        public int SponsorId { get; set; }
        public double AmountContributed { get; set; }
        public DateTime DateOfContribution { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
