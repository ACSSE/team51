using System;
using Bursify.Data.EF.Entities.Bridge;
using System.Collections.Generic;
using System.Linq;

namespace Bursify.Web.Models
{
    public class CampaignSponsorViewModel
    {
        public int CampaignId { get; set; }
        public int SponsorId { get; set; }
        public double AmountContributed { get; set; }
        public DateTime DateOfContribution { get; set; }
        public string Name { get; set; }

        public CampaignSponsorViewModel(CampaignSponsor campaignSponsor)
        {
            CampaignId = campaignSponsor.CampaignId;
            SponsorId = campaignSponsor.SponsorId;
            AmountContributed = campaignSponsor.AmountContributed;
            DateOfContribution = campaignSponsor.DateOfContribution;
        }

        public CampaignSponsorViewModel() { }

        public CampaignSponsorViewModel SingleMap(CampaignSponsor cs)
        {
            CampaignId = cs.CampaignId;
            SponsorId = cs.SponsorId;
            AmountContributed = cs.AmountContributed;
            DateOfContribution = cs.DateOfContribution;

            return this;
        }

        public static List<CampaignSponsorViewModel> MapMultiple(List<CampaignSponsor> csList)
        {
            //reportViewModels.Select(sub => (new RequirementViewModel()).MapSingleSubject(sub)).ToList();
            return csList.Select(cs => (new CampaignSponsorViewModel()).SingleMap(cs)).ToList();
        }
    }
}