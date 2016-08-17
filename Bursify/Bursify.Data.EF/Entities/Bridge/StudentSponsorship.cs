using System;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Data.EF.Entities.Bridge
{
    public class StudentSponsorship : IBridgeEntity
    {
        //public int ID { get; set; }
        public int StudentId { get; set; }
        public int SponsorshipId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public bool SponsorshipOffered { get; set; }

        public virtual Student Student { get; set; }
        public virtual Sponsorship Sponsorship { get; set; }



        public int leftId
        {
            get { return StudentId; }
        }

        public int rightId
        {
            get { return SponsorshipId; }
        }
    }
}
