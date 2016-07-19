using System;
using Bursify.Data.EF.SponsorUser;

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

        public SponsorshipViewModel(Sponsorship sponsorship)
        {
            SponsorshipId = sponsorship.SponsorshipId;
            SponsorId = sponsorship.SponsorId;
            Name = sponsorship.Name;
            Description = sponsorship.Description;
            ClosingDate = sponsorship.ClosingDate;
            EssayRequired = sponsorship.EssayRequired;
            SponsorshipValue = sponsorship.SponsorshipValue;
            StudyFields = sponsorship.StudyFields;
            Province = sponsorship.Province;
            AverageMarkRequired = sponsorship.AverageMarkRequired;
            EducationLevel = sponsorship.EducationLevel;
            PreferredInstitutions = sponsorship.PreferredInstitutions;
            ExpensesCovered = sponsorship.ExpensesCovered;
            TermsAndConditions = sponsorship.TermsAndConditions;
        }
    }
}