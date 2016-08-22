using System;
using Bursify.Data.EF.Entities.Bridge;
using System.Collections.Generic;
using System.Linq;

namespace Bursify.Web.Models
{
    public class StudentSponsorshipViewModel
    {
        public int StudentId { get; set; }
        public int SponsorshipId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public bool SponsorshipOffered { get; set; }

        public StudentSponsorship MapSIngleStudentSponsorship(StudentSponsorship studentSponsorship)
        {
            return new StudentSponsorship()
            {
                StudentId = studentSponsorship.StudentId,
                SponsorshipId = studentSponsorship.SponsorshipId,
                SponsorshipOffered = studentSponsorship.SponsorshipOffered,
                ApplicationDate = studentSponsorship.ApplicationDate,
                Status = studentSponsorship.Status
            };
        }

        public List<StudentSponsorship> MapMultipleStudentSponsorships(List<StudentSponsorship> studentSponsorships)
        {
            return
                (from studentSponsorship in studentSponsorships select MapSIngleStudentSponsorship(studentSponsorship)).ToList();
        }
    }
}