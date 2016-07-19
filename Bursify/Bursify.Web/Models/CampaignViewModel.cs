using System;
using Bursify.Data.EF.CampaignUser;

namespace Bursify.Web.Models
{
    public class CampaignViewModel
    {
        public int CampaignId { get; set; }
        public int StudentId { get; set; }
        public string CampaignName { get; set; }
        public string Tagline { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double AmountRequired { get; set; }
        public string CampaignType { get; set; }
        public string VideoPath { get; set; }
        public string PicturePath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountContributed { get; set; }
        public string FundUsage { get; set; }
        public string ReasonsToSupport { get; set; }
        
        public CampaignViewModel(Campaign campaign)
        {
            CampaignId = campaign.CampaignId;
            StudentId = campaign.StudentId;
            CampaignName = campaign.CampaignName;
            Tagline = campaign.Tagline;
            Location = campaign.Location;
            Description = campaign.Description;
            AmountRequired = campaign.AmountRequired;
            CampaignType = campaign.CampaignType;
            VideoPath = campaign.VideoPath;
            PicturePath = campaign.PicturePath;
            StartDate = campaign.StartDate;
            EndDate = campaign.EndDate;
            AmountContributed = campaign.AmountContributed;
            FundUsage = campaign.FundUsage;
            ReasonsToSupport = campaign.ReasonsToSupport;
        }
    }
}