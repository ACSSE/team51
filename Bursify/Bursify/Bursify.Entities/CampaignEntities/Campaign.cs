using Bursify.Entities.StudentEntities;
using Bursify.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Entities.CampaignEntities
{

    public class Campaign : IEntityBase
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

        public int ID
        {
            get { return CampaignId; }
        }

        public virtual Account Account { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<CampaignSponsor> CampaignSponsors { get; set; }
    }
}
