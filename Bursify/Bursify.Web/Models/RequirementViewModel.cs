using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class RequirementViewModel
    {
        public int ID { get; set; }
        public int SponsorshipId { get; set; }
        public string Name { get; set; }
        public int MarkRequired { get; set; }

        public RequirementViewModel MapSingleSubject(Requirement requirement)
        {
            ID = requirement.ID;
            SponsorshipId = requirement.SponsorshipId;
            Name = requirement.Name;
            MarkRequired = requirement.MarkRequired;

            return this;
        }

        public Requirement ReverseMap()
        {
            return new Requirement()
            {
                ID = this.ID,
                SponsorshipId = this.SponsorshipId,
                Name = this.Name,
                MarkRequired = this.MarkRequired
            };
        }

        public RequirementViewModel ReverseMap(Requirement requirement)
        {
            return new RequirementViewModel()
            {
                ID = requirement.ID,
                SponsorshipId = requirement.SponsorshipId,
                Name = requirement.Name,
                MarkRequired = requirement.MarkRequired
            };
        }

        public static List<RequirementViewModel> ReverseMapSubjects(List<Requirement> subjects)
        {
            var subjectViewModel = new RequirementViewModel();

            return subjects.Select(subject => subjectViewModel.ReverseMap(subject)).ToList();
            //return subjects.Select(subjectViewModel.ReverseMap).ToList();
        }

        public static List<RequirementViewModel> MapMultipleSubjects(List<Requirement> reportViewModels)
        {
            //var subjectViewModel = (new SubjectViewModel());

            return reportViewModels.Select(sub => (new RequirementViewModel()).MapSingleSubject(sub)).ToList();
        }
    }
}