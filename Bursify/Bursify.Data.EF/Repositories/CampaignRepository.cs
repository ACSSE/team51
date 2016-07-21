using System.Collections.Generic;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignRepository : Repository<Campaign>
    {
        public CampaignRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public Campaign GetCampaign(int id)
        {
            return FindSingle(campaignId => campaignId.CampaignId == id);
        }

        public IEnumerable<Campaign> FindCampaigns(string criteria)
        {
            var filteredCampaigns = FindMany(campaign => 
                                  campaign.Location.ToUpper().Contains(criteria)
                               || campaign.Description.ToUpper().Contains(criteria)
                               || campaign.CampaignName.ToUpper().Contains(criteria)
                               || campaign.CampaignType.ToUpper().Contains(criteria));
           
            return filteredCampaigns;
        }
    }
}