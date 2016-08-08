using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorshipViewModel
    {
        public int ID { get; set; }
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

        public SponsorshipViewModel()
        {
        }

        public SponsorshipViewModel(Sponsorship s)
        {
            SingleSponsorshipMap(s);
        }

        public SponsorshipViewModel SingleSponsorshipMap(Sponsorship sponsorship)
        {

            ID = sponsorship.ID;
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
            SponsorshipType = SponsorshipType;
            return this;

        }

        public Sponsorship ReverseMap()
        {
            var sponsorship = new Sponsorship
            {
                Name = this.Name,
                EducationLevel = this.EducationLevel,
                ClosingDate = this.ClosingDate,
                SponsorshipValue = this.SponsorshipValue,
                AverageMarkRequired = this.AverageMarkRequired,
                Description = this.Description,
                EssayRequired = this.EssayRequired,
                ExpensesCovered = this.ExpensesCovered,
                PreferredInstitutions = this.PreferredInstitutions,
                Province = this.Province,
                SponsorId = this.SponsorId,
                SponsorshipType = this.SponsorshipType,
                StudyFields = this.StudyFields,
                TermsAndConditions = this.TermsAndConditions
            };
            return sponsorship;
        }

        public static List<SponsorshipViewModel> MultipleSponsorshipsMap(List<Sponsorship> sponsorships)
        {
            List<SponsorshipViewModel> sponsorshipVM = new List<SponsorshipViewModel>();
            foreach (var s in sponsorships)
            {
                SponsorshipViewModel sVm = new SponsorshipViewModel(s);
                sponsorshipVM.Add(sVm);
            }
            return sponsorshipVM;
        }
    }
}