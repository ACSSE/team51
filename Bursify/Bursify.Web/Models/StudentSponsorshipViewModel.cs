using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class StudentSponsorshipViewModel
    {
        public int StudentId { get; set; }
        public int SponsorshipId { get; set; }
        public DateTime ApplicationDate { get; set; }

        public StudentSponsorshipViewModel(StudentSponsorship studentSponsorship)
        {
            StudentId = studentSponsorship.StudentId;
            SponsorshipId = studentSponsorship.SponsorshipId;
            ApplicationDate = studentSponsorship.ApplicationDate;
        }
    }
}