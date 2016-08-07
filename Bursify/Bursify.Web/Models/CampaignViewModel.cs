using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Web.Models
{
    public class CampaignViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
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
        public string Status { get; set; }

        public CampaignViewModel()
        {
        }

        public CampaignViewModel(Campaign c)
        {
            SingleCampaignMap(c);
        }

        public CampaignViewModel SingleCampaignMap(Campaign campaign)
        { 
            CampaignId = campaign.ID;
            StudentId = campaign.StudentId;
            CampaignName = campaign.CampaignName;
            Tagline = campaign.Tagline;
            Location = campaign.Location;
            Description = campaign.Location;
            AmountRequired = campaign.AmountRequired;
            CampaignType = campaign.CampaignType;
            VideoPath = campaign.VideoPath;
            PicturePath = campaign.PicturePath;
            StartDate = campaign.StartDate;
            EndDate = campaign.EndDate;
            AmountContributed = campaign.AmountContributed;
            FundUsage = campaign.FundUsage;
            ReasonsToSupport = campaign.ReasonsToSupport;
            Status = campaign.Status;
      
            return this;
        }

        public Campaign ReverseMap()
        {
            return new Campaign()
            {
                ID = this.CampaignId,
                StudentId = this.StudentId,
                CampaignName = this.CampaignName,
                Tagline = this.Tagline,
                Location = this.Location,
                Description = this.Description,
                AmountRequired = this.AmountRequired,
                CampaignType = this.CampaignType,
                VideoPath = this.VideoPath,
                PicturePath = this.PicturePath,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                AmountContributed = this.AmountContributed,
                FundUsage = this.FundUsage,
                ReasonsToSupport = this.ReasonsToSupport
            };
        }

        public static List<CampaignViewModel> MultipleCampaignsMap(List<Campaign> campaigns)
        {
            List<CampaignViewModel> campaignsVM = new List<CampaignViewModel>();
            foreach (var s in campaigns)
            {
                CampaignViewModel sVm = new CampaignViewModel(s);
                campaignsVM.Add(sVm);
            }
            return campaignsVM;
        }
    }
}