using Bursify.Data.EF;
using Bursify.Data.Enums;
using Bursify.Data.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.SponsorUser
{
    public class Sponsorship 
    {
        public int BursifyUserId { get; set; }
        public string Name { get; set; }
        public SponsorshipType SponsorshipType { get; set; }
        public string Description { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool EssayRequired { get; set; }
        public double EstimatedValue { get; set; }
        [Key, ForeignKey("Requirements")]
        public int RequirementId { get; set; }

        public virtual Requirement Requirements { get; set; }
    }
}