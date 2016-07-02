using Bursify.Data.EF;
using Bursify.Data.Enums;
using Bursify.Data.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.SponsorUser
{
    public class Sponsorship : IEntity
    {
        public int SponsorshipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool EssayRequired { get; set; }
        public double EstimatedCost { get; set; }
        public string StudyFields { get; set; }
        public string Province { get; set; }
        public int AverageMarkRequired { get; set; }
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsorships { get; set; }
        public int Id
        {
            get { return SponsorshipId; }
        }
    }
}