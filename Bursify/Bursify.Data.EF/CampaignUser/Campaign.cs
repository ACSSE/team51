using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bursify.Data.Enums;
using Bursify.Data.StudentUser;
using Bursify.Data.EF;
using System.Collections.Generic;

namespace Bursify.Data.CampaignUser
{
    public class Campaign : IEntity
    {
        public Campaign()
        {
            Accounts = new List<Account>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Tagline { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public double AmountRequired { get; set; }
        public string CampaignType { get; set; }
        public string VideoPath { get; set; }
        public string PicturePath { get; set; }
        public DateTime Deadline { get; set; }
        public double AmountContributed { get; set; }
        public int StudentId { get; set; }
        public Student CampaignUser { get; set; }

        public int Id
        {
            get { return CampaignId; }
        }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}