using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.StudentUser
{
    public class Student : IEntity
    {
        public Student()
        {
            Campaigns = new List<Campaign>();
        }

        //unique identifier
        //foreign key
        public int ID { get; set; }
        public int InstitutionID { get; set; }
        public string IDNumber { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string EducationLevel { get; set; }
        public int AverageMark { get; set; }
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public bool HasDisability { get; set; }
        public string DisabilityDescription { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string CurrentOccupation { get; set; }
        public string StudyField { get; set; }
        public string HighestAcademicAchievement { get; set; }
        public long YearOfAcademicAchievement { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfViews { get; set; }
        public string Essay { get; set; }
        public string GuardianPhone { get; set; }
        public string GuardianRelationship { get; set; }
        public string GuardianEmail { get; set; }
        public string IDDocumentPath { get; set; }
        public string MatricCertificatePath { get; set; }
        public string CVPath { get; set; }
        public bool AgreeTandC { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }    //required
        public ICollection<StudentReport> StudentReports { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual Institution Institution { get; set; }
        public ICollection<StudentSponsorship> StudentSponsorships { get; set; }
        public virtual ICollection<SponsorStudentNotification> SponsorStudentNotification { get; set; }
    }
}