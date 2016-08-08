using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignReportRepository : BridgeRepository<CampaignReport>
    {
        public CampaignReportRepository(DataSession dataSession) : base(dataSession)
        {
        }


        public List<Campaign> GetReportedCampaigns()
        {
            return LoadAll().Select(x => x.Campaign).ToList();
        }

        public List<CampaignReport> GetReportedByCampaignId(int Id)
        {
            return LoadAll().Where(x => x.CampaignId == Id).ToList();
        }
    }
}
