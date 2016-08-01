using System;
using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class CampaignSponsorViewModel
    {
        public int CampaignId { get; set; }
        public int SponsorId { get; set; }
        public double AmountContributed { get; set; }
        public DateTime DateOfContribution { get; set; }

        public CampaignSponsorViewModel(CampaignSponsor campaignSponsor)
        {
            CampaignId = campaignSponsor.CampaignId;
            SponsorId = campaignSponsor.SponsorId;
            AmountContributed = campaignSponsor.AmountContributed;
            DateOfContribution = campaignSponsor.DateOfContribution;
        }
    }
}