using Bursify.Data.EF;
using Bursify.Data.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.SponsorUser
{
    public class Sponsor 
    {
        public int BursifyUserId { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int NumberOfStudentsSponsoring { get; set; }
        [Key, ForeignKey("Sponsorships")]
        public int SponsorshipId { get; set; }

        public virtual Sponsorship Sponsorships { get; set; }
    }
}