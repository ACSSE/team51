using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;
using Microsoft.Ajax.Utilities;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignSponsorRepository : Repository<CampaignSponsor>
    {
        public CampaignSponsorRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Campaign> GetSupportedCamapigns(int sponsorId)
        {
            var campaigns = FindMany(x => x.SponsorId == sponsorId).DistinctBy(x => x.CampaignId).Select(x => x.Campaign).ToList();
            return campaigns;
        }

        public int GetNumberOfSupportersOfCampaign(int Id)
        {
            return FindMany(x => x.CampaignId == Id).DistinctBy(x => x.SponsorId).Count();
        }

        //saves by adding amount if has an entry already
        //public void SaveByAdding(CampaignSponsor entity)
        //{
        //    var existing = LoadById(entity.ID);

        //    if (existing == null)
        //    {
        //        DbContext.Set<CampaignSponsor>().Add(entity);
        //    }
        //    else
        //    {
        //        string entitySetName = GetEntitySetName<CampaignSponsor>();
        //        entity.AmountContributed += existing.AmountContributed;
        //        ObjectContext.ApplyCurrentValues(entitySetName, entity);
        //    }

        //    ObjectContext.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
        //}
    }
}
