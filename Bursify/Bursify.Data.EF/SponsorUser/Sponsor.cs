using Bursify.Data.EF;
using Bursify.Data.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.SponsorUser
{
    public class Sponsor : IEntity
    {
        public Sponsor()
        {
            Sponsorhips = new List<Sponsorship>();
        }

        public int SponsorId { get; set; }
        public int NumberOfStudentsSponsored { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int BursifyUserId { get; set; }
        public virtual BursifyUser SponsorUser { get; set; }
        public int Id
        {
            get { return SponsorId; }
        }

        public ICollection<Sponsorship> Sponsorhips { get; set; }
    }
}