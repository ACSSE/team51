using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;

namespace Bursify.Data.EF.User
{
    public class StudentSponsorship
    {
        public int StudentId { get; set; }
        public int SponsorshipId { get; set; }
        public DateTime ApplicationDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Sponsorship Sponsorship { get; set; }
    }
}
