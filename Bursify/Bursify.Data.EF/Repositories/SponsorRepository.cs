using System.Collections.Generic;
using Bursify.Data.EF.Uow;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;

namespace Bursify.Data.EF.Repositories
{
    public class SponsorRepository : Repository<Sponsor>
    {
        public SponsorRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Sponsor> GetAllSponsors()
        {
            return LoadAll();
        }

        public Sponsor GetSponsor(int id)
        {
            return FindSingle(sponsorId => sponsorId.ID == id);
        }
         
        public List<Sponsor> GetTop10Sponsors()
        {
            var topSponsors = (from sponsor in DbContext.Set<Sponsor>()
                                orderby sponsor.BursifyRank
                                select sponsor
                                ).Distinct()
                                .Take(10)
                                .ToList();

            return topSponsors;
        }
    }
}