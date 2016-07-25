using System;
using System.Collections.Generic;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.StudentUser
{
    public class Student : IEntity
    {
        public Student()
        {
            Campaigns = new List<Campaign>();
            Sponsorships = new List<Sponsorship>();
        }

        //unique identifier
        //foreign key
        public int ID { get; set; }
        public string Surname { get; set; }
        public string EducationLevel { get; set; }
        public int AverageMark { get; set; }
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public bool HasDisability { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string CurrentOccupation { get; set; }
        public string HighestAcademicAchievement { get; set; }
        public long YearOfAcademicAchievement { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfViews { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }    //required
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual ICollection<Sponsorship> Sponsorships { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; } 
        public ICollection<StudentSponsorship> StudentSponsorships { get; set; } 
    }
}