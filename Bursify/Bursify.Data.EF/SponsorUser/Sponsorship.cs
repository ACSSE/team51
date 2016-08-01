using System;
using System.Collections.Generic;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.SponsorUser
{
    public class Sponsorship : IEntity
    {
        public Sponsorship()
        {
            Students = new List<Student>();
        }

        public int ID { get; set; }
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string SponsorshipType { get; set; }
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
        public int NumberOfViews { get; set; }

        public virtual Sponsor Sponsor { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public ICollection<StudentSponsorship> StudentSponsorships { get; set; }
        public ICollection<SponsorshipRequirement> Requirements { get; set; } 
    }
}