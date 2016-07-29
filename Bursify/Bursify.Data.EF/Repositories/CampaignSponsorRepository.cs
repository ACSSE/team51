using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignSponsorRepository : BridgeRepository<CampaignSponsor>
    {
        public CampaignSponsorRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Campaign> GetSupportedCamapigns(int sponsorId)
        {
            var campaigns = FindMany(x => x.SponsorId == sponsorId).Select(x => x.Campaign).ToList();
            return campaigns;
        }
    }
}
