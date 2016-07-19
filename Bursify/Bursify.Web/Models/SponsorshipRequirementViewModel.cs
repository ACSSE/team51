using Bursify.Data.EF.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorshipRequirementViewModel
    {
        public int SponsorshipId { get; set; }
        public int SubjectId { get; set; }
        public int RequiredMark { get; set; }

        public SponsorshipRequirementViewModel(SponsorshipRequirement requirement)
        {
            SponsorshipId = requirement.SponsorshipId;
            SubjectId = requirement.SubjectId;
            RequiredMark = requirement.RequiredMark;
        }
    }
}