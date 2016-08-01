using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class StudentSponsorshipViewModel
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int SponsorshipId { get; set; }
        public bool IsSponsorshipOffered { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string SponsorshipConfirmed { get; set; }

        public StudentSponsorship MapSIngleStudentSponsorship(StudentSponsorship studentSponsorship)
        {
            return new StudentSponsorship()
            {
                ID = studentSponsorship.ID,
                StudentId = studentSponsorship.StudentId,
                SponsorshipId = studentSponsorship.SponsorshipId,
                IsSponsorshipOfferd = studentSponsorship.IsSponsorshipOfferd,
                ApplicationDate = studentSponsorship.ApplicationDate
            };
        }

        public List<StudentSponsorship> MapMultipleStudentSponsorships(List<StudentSponsorship> studentSponsorships)
        {
            return
                (from studentSponsorship in studentSponsorships select MapSIngleStudentSponsorship(studentSponsorship)).ToList();
        }
    }
}