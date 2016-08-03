
﻿using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.SponsorUser;

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