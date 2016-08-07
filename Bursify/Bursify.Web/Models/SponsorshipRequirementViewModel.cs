
﻿using System.Collections.Generic;
﻿using Bursify.Data.EF.Entities.Bridge;

namespace Bursify.Web.Models
{
    public class SponsorshipRequirementViewModel
    {
        public int SponsorshipId { get; set; }
        public int SubjectId { get; set; }
        public int RequiredMark { get; set; }


        public SponsorshipRequirementViewModel()
        {
        }

        public SponsorshipRequirementViewModel(SponsorshipRequirement sr)
        {
            SingleSponsorshipRequirementMap(sr);
        }

        public SponsorshipRequirementViewModel SingleSponsorshipRequirementMap(SponsorshipRequirement sponsorship)
        {
            this.SponsorshipId = sponsorship.SponsorshipId;
            this.SubjectId = sponsorship.SubjectId;
            this.RequiredMark = sponsorship.RequiredMark;
            return this;
        }

        public SponsorshipRequirement ReverseMap()
        {
            return new SponsorshipRequirement()
            {
                SponsorshipId = this.SponsorshipId,
                SubjectId = this.SubjectId,
                RequiredMark = this.RequiredMark
            };
        }

        public static List<SponsorshipRequirementViewModel> MultipleSponsorshipsMap(List<SponsorshipRequirement> sponsorshipsRequirements)
        {
            List<SponsorshipRequirementViewModel> sponsorshipRequirementsVM = new List<SponsorshipRequirementViewModel>();
            foreach (var s in sponsorshipsRequirements)
            {
                SponsorshipRequirementViewModel sVm = new SponsorshipRequirementViewModel(s);
                sponsorshipRequirementsVM.Add(sVm);
            }
            return sponsorshipRequirementsVM;
        }

    }
}