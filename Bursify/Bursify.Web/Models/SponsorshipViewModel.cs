using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorshipViewModel
    {
        public int SponsorshipId { get; set; }
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool EssayRequired { get; set; }
        public double SponsorshipValue { get; set; }
        public string StudyFields { get; set; }
        public string Province { get; set; }
        public int AverageMarkRequired { get; set; }
        public string EducationLevel { get; set; }
        public string PreferredInstitutions { get; set; }
        public string ExpensesCovered { get; set; }
        public string TermsAndConditions { get; set; }
        public string SponsorshipType { get; set; }

        public Sponsorship SingleSponsorshipMap(Sponsorship sponsorship)
        {
            return new Sponsorship()
            {
                ID = sponsorship.ID,
                SponsorId = sponsorship.SponsorId,
                Name = sponsorship.Name,
                Description = sponsorship.Description,
                ClosingDate = sponsorship.ClosingDate,
                EssayRequired = sponsorship.EssayRequired,
                SponsorshipValue = sponsorship.SponsorshipValue,
                StudyFields = sponsorship.StudyFields,
                Province = sponsorship.Province,
                AverageMarkRequired = sponsorship.AverageMarkRequired,
                EducationLevel = sponsorship.EducationLevel,
                PreferredInstitutions = sponsorship.PreferredInstitutions,
                ExpensesCovered = sponsorship.ExpensesCovered,
                TermsAndConditions = sponsorship.TermsAndConditions,
                SponsorshipType = SponsorshipType
            };
        }

        public List<Sponsorship> MultipleSponsorshipsMap(List<Sponsorship> sponsorships)
        {
            return (from sponsorship in sponsorships select SingleSponsorshipMap(sponsorship)).ToList();
        }
    }
}