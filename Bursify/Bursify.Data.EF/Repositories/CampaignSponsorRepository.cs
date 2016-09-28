using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Uow;
using Microsoft.Ajax.Utilities;

namespace Bursify.Data.EF.Repositories
{
    public class CampaignSponsorRepository : Repository<CampaignSponsor>
    {
        private readonly DataSession _dataSession;

        public CampaignSponsorRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public List<Campaign> GetSupportedCamapigns(int sponsorId)
        {
            var campaigns =
                FindMany(x => x.SponsorId == sponsorId).DistinctBy(x => x.CampaignId).Select(x => x.Campaign).ToList();
            return campaigns;
        }

        public int GetNumberOfSupportersOfCampaign(int Id)
        {
            return FindMany(x => x.CampaignId == Id).DistinctBy(x => x.SponsorId).Count();
        }

        public List<string> GetCampaignFunders(int campaignId)
        {
            var sponsors = FindMany(x => x.CampaignId == campaignId);

            List<string> sponsorNames = sponsors.Select(sponsor =>
                _dataSession.UnitOfWork.Context.Set<Sponsor>()
                    .Where(x => x.ID == sponsor.SponsorId)
                    .Select(x => x.CompanyName)
                    .FirstOrDefault())
                .ToList();

            return sponsorNames;
        }

        public int GetNumberOfFunders(int campaignId)
        {
            var count = FindMany(x => x.CampaignId == campaignId).DistinctBy(x => x.SponsorId).Count();

            return count;
        }

        public Dictionary<int?, double> GetFundingPerDay(int campaignId)
        {
            var dailyFunding = _dataSession.UnitOfWork.Context.Set<CampaignSponsor>()
                .Where(x => x.CampaignId == campaignId)
                .GroupBy(x => SqlFunctions.DatePart("day", x.DateOfContribution))
                .ToDictionary(v => v.Key, v => v.Sum(c => c.AmountContributed));

            return dailyFunding;
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