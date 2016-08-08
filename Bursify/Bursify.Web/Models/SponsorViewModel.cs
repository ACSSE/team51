using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorViewModel
    {
        public int ID { get; set; }
        public int NumberOfStudentsSponsored { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int NumberOfApplicants { get; set; }
        public int BursifyRank { get; set; }
        public int BursifyScore { get; set; }

        public SponsorViewModel()
        {
        }

        public SponsorViewModel(Sponsor s)
        {
            SingleSponsorMap(s);
        }

        public SponsorViewModel SingleSponsorMap(Sponsor sponsor)
        {
                ID = sponsor.ID;
                NumberOfStudentsSponsored = sponsor.NumberOfStudentsSponsored;
                NumberOfSponsorships = sponsor.NumberOfSponsorships;
                NumberOfApplicants = sponsor.NumberOfApplicants;
                BursifyRank = sponsor.BursifyRank;
                BursifyScore = sponsor.BursifyScore;
                return this;
        }

        public Sponsor ReverseMap()
        {
            return new Sponsor()
            {
                ID = this.ID,
                NumberOfStudentsSponsored = this.NumberOfStudentsSponsored,
                NumberOfSponsorships = this.NumberOfSponsorships,
                NumberOfApplicants = this.NumberOfApplicants,
                BursifyRank = this.BursifyRank,
                BursifyScore = this.BursifyScore
            };
        }

        public static List<SponsorViewModel> MultipleSponsorsMap(List<Sponsor> sponsors)
        {
            List<SponsorViewModel> sponsorsVm = new List<SponsorViewModel>();
            foreach (var i in sponsors)
            {
                SponsorViewModel sVm = new SponsorViewModel(i);
                sponsorsVm.Add(sVm);
            }
            return sponsorsVm;
        }

    }
}