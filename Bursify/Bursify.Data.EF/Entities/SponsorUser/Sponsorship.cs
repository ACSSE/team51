﻿using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.SponsorUser
{
    public class Sponsorship : IEntity
    {
        public Sponsorship()
        {
            Requirements = new List<Requirement>();
        }

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
        
        public virtual Sponsor Sponsor { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
        public ICollection<StudentSponsorship> StudentSponsorships { get; set; }
    }
}