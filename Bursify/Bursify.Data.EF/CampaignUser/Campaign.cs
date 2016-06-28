using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bursify.Data.Enums;

namespace Bursify.Data.CampaignUser
{
    public class Campaign
    {
        public int BursifyUserId { get; set; }
        public string Name { get; set; }
        public double RequiredAmount { get; set; }
        public double AmountAcquired { get; set; }
        public DateTime Deadline { get; set; }
        public CampaignType CampaignType { get; set; }

        [Key, ForeignKey("Account")]
        public int AccountId { get; set; }

        public virtual Account Accounts { get; set; }
    }
}