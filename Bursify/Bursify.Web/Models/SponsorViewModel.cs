using Bursify.Data.EF.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorViewModel
    {
        public int BursifyUserId { get; set; }
        public int NumberOfStudentsSponsored { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int NumberOfApplicants { get; set; }
        public int BursifyRank { get; set; }
        public int BursifyScore { get; set; }

        public SponsorViewModel(Sponsor sponsor)
        {
            BursifyUserId = sponsor.BursifyUserId;
            NumberOfStudentsSponsored = sponsor.NumberOfStudentsSponsored;
            NumberOfSponsorships = sponsor.NumberOfSponsorships;
            NumberOfApplicants = sponsor.NumberOfApplicants;
            BursifyRank = sponsor.BursifyRank;
            BursifyScore = sponsor.BursifyScore;
        }
    }
}