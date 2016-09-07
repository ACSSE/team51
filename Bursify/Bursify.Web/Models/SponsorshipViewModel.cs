using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorshipViewModel
    {
        public int ID { get; set; }
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string SponsorshipType { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool EssayRequired { get; set; }
        public double SponsorshipValue { get; set; }
        public string StudyFields { get; set; }
        public string Province { get; set; }
        public int AverageMarkRequired { get; set; }
        public string EducationLevel { get; set; }
        public string InstitutionPreference { get; set; }
        public string GenderPreference { get; set; }
        public string RacePreference { get; set; }
        public bool DisabilityPreference { get; set; }
        public string ExpensesCovered { get; set; }
        public string TermsAndConditions { get; set; }
        public int NumberOfViews { get; set; }
        public string AgeGroup { get; set; }
        public int Rating { get; set; }

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
            StartingDate = sponsorship.StartingDate;
            ClosingDate = sponsorship.ClosingDate;
            EssayRequired = sponsorship.EssayRequired;
            SponsorshipValue = sponsorship.SponsorshipValue;
            StudyFields = sponsorship.StudyFields;
            Province = sponsorship.Province;
            AverageMarkRequired = sponsorship.AverageMarkRequired;
            EducationLevel = sponsorship.EducationLevel;
            InstitutionPreference = sponsorship.InstitutionPreference;
            GenderPreference = sponsorship.GenderPreference;
            RacePreference = sponsorship.RacePreference;
            DisabilityPreference = sponsorship.DisabilityPreference;
            ExpensesCovered = sponsorship.ExpensesCovered;
            TermsAndConditions = sponsorship.TermsAndConditions;
            SponsorshipType = SponsorshipType;
            AgeGroup = sponsorship.AgeGroup;
            Rating = sponsorship.Rating;
            return this;

        }

        public Sponsorship ReverseMap()
        {
            var sponsorship = new Sponsorship
            {
                Name = this.Name,
                EducationLevel = this.EducationLevel,
                StartingDate = this.StartingDate,
                ClosingDate = this.ClosingDate,
                SponsorshipValue = this.SponsorshipValue,
                AverageMarkRequired = this.AverageMarkRequired,
                Description = this.Description,
                EssayRequired = this.EssayRequired,
                ExpensesCovered = this.ExpensesCovered,
                InstitutionPreference = this.InstitutionPreference,
                GenderPreference = this.GenderPreference,
                RacePreference = this.RacePreference,
                DisabilityPreference = this.DisabilityPreference,
                Province = this.Province,
                SponsorId = this.SponsorId,
                SponsorshipType = this.SponsorshipType,
                StudyFields = this.StudyFields,
                TermsAndConditions = this.TermsAndConditions,
                AgeGroup = this.AgeGroup,
                Rating = this.Rating
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