using System.Collections.Generic;
using Bursify.Data.EF.Repositories;
using Bursify.Entities.SponsorEntities;

namespace Bursify.Data.Repositories
{
    public class SponsorRepository : Repository<Sponsor>
    {
        public SponsorRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Sponsor> GetTopTenSponsors()
        {
            var many = this.FindMany(x => x.BursifyRank == 1 && x.BursifyUser.Email.StartsWith("blah"));

            var topSponsors = ((from sponsor in DbContext.Set<Sponsor>()
                                orderby sponsor.BursifyRank
                                select sponsor).Distinct().Take(10)).ToList();

            return topSponsors;
        }

    }
}