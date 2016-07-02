using Bursify.Data.SponsorUser;
using Bursify.Data.StudentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.StudentUser
{
    public class StudentSponsorship
    {
        public int StudentId { get; set; }
        public virtual Student student { get; set; }    //student id

        public int SponsorshipId { get; set; }
        public virtual Sponsorship sponsorship { get; set; }   //sponsorship id

        public DateTime DateSponsored { get; set; }
    }
}
