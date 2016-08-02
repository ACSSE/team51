using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.Campaigns
{
    public class Campaign : IEntity
    {
        public int ID { get; set; }
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
        public int NumberOfUpVotes { get; set; }

        public virtual Account Account { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<CampaignSponsor> CampaignSponsors { get; set; }
        public virtual ICollection<CampaignReport> CampaignReports { get; set; }
        public virtual ICollection<BursifyUser> Upvotes { get; set; }
    }
}