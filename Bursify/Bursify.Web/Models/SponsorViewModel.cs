using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Web.Models
{
    public class SponsorViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(34, MinimumLength = 3, ErrorMessage = "This string myust be ballin'")]
        public string CompanyName { get; set; }

        
        public int NumberOfStudentsSponsored { get; set; }
        public int NumberOfSponsorships { get; set; }
        public int NumberOfApplicants { get; set; }
        public int BursifyRank { get; set; }
        public int BursifyScore { get; set; }
        public string CompanyEmail { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }

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
            CompanyName = sponsor.CompanyName;
            NumberOfStudentsSponsored = sponsor.NumberOfStudentsSponsored;
            NumberOfSponsorships = sponsor.NumberOfSponsorships;
            NumberOfApplicants = sponsor.NumberOfApplicants;
            BursifyRank = sponsor.BursifyRank;
            BursifyScore = sponsor.BursifyScore;
            CompanyEmail = sponsor.CompanyEmail;
            Website = sponsor.Website;
            Industry = sponsor.Industry;
            Location = sponsor.Location;
            return this;
        }

        public Sponsor ReverseMap()
        {
            return new Sponsor()
            {
                ID = this.ID,
                CompanyName = this.CompanyName,
                NumberOfStudentsSponsored = this.NumberOfStudentsSponsored,
                NumberOfSponsorships = this.NumberOfSponsorships,
                NumberOfApplicants = this.NumberOfApplicants,
                BursifyRank = this.BursifyRank,
                BursifyScore = this.BursifyScore,
                CompanyEmail = this.CompanyEmail,
                Website = this.Website,
                Industry = this.Industry,
                Location = this.Location
            };
        }

        public Sponsor ReverseMap(Sponsor model)
        {
            return new Sponsor()
            {
                ID = model.ID,
                CompanyName = model.CompanyName,
                NumberOfStudentsSponsored = model.NumberOfStudentsSponsored,
                NumberOfSponsorships = model.NumberOfSponsorships,
                NumberOfApplicants = model.NumberOfApplicants,
                BursifyRank = model.BursifyRank,
                BursifyScore = model.BursifyScore,
                CompanyEmail = model.CompanyEmail,
                Website = model.Website,
                Industry = model.Industry,
                Location = model.Location
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