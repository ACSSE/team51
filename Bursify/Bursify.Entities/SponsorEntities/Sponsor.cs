using Bursify.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Entities.SponsorEntities
{
    public class Sponsor : IEntityBase
    {
        public Sponsor()
        {
            Sponsorhips = new List<Sponsorship>();
        }

        public int BursifyUserId { get; set; }
        public int NumberOfStudentsSponsored { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int NumberOfApplicants { get; set; }
        public int BursifyRank { get; set; }
        public int BursifyScore { get; set; }

        public int ID
        {
            get { return BursifyUserId; }
        }

        public virtual BursifyUser BursifyUser { get; set; }
        public ICollection<Sponsorship> Sponsorhips { get; set; }
        public virtual ICollection<CampaignSponsor> CampaignSponsors { get; set; }
    }
}
