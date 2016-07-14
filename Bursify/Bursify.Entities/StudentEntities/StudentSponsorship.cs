
using Bursify.Entities.SponsorEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Entities.StudentEntities
{
    public class StudentSponsorship
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        [Key, Column(Order = 1)]
        public int SponsorshipId { get; set; }
        public DateTime ApplicationDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Sponsorship Sponsorship { get; set; }
    }
}
