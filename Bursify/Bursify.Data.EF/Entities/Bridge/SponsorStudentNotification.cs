using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using System;

namespace Bursify.Data.EF.Entities.Bridge
{
    public class SponsorStudentNotification : IEntity
    {
        public int ID { get; set; }
        public int SponsorId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateNotified { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public virtual Sponsor Sponsor { get; set; }
        public virtual Student Student { get; set; }

    }
}
