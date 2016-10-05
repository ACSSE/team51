using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ApplicationViewModel
    {
        public int SponsorshipId { get; set; }
        public string SponsorName { get; set; }
        public string SponsorshipName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Status { get; set; }
        public bool SponsorshipOffered { get; set; }

        public ApplicationViewModel(int sponsorshipId, string sponsorName, string sponsorshipName, DateTime appDate, DateTime closingDate, string status)
        {
            SponsorshipId = sponsorshipId;
            SponsorName = sponsorName;
            SponsorshipName = sponsorshipName;
            ApplicationDate = appDate;
            ClosingDate = closingDate;
            Status = status;
        }

        //public StudentSponsorship MapSIngleStudentSponsorship(StudentSponsorship studentSponsorship)
        //{
        //    return new StudentSponsorship()
        //    {
        //        StudentId = studentSponsorship.StudentId,
        //        SponsorshipId = studentSponsorship.SponsorshipId,
        //        SponsorshipOffered = studentSponsorship.SponsorshipOffered,
        //        ApplicationDate = studentSponsorship.ApplicationDate,
        //        Status = studentSponsorship.Status
        //    };
        //}

        //public List<StudentSponsorship> MapMultipleStudentSponsorships(List<StudentSponsorship> studentSponsorships)
        //{
        //    return
        //        (from studentSponsorship in studentSponsorships select MapSIngleStudentSponsorship(studentSponsorship)).ToList();
        //}
    }
}