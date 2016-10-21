using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.User;
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

        public Dictionary<int?, double> GetFundingPerDay(int campaignId, int month)
        {
            var dailyFunding = _dataSession.UnitOfWork.Context.Set<CampaignSponsor>()
                .Where(x => x.CampaignId == campaignId && SqlFunctions.DatePart("month", x.DateOfContribution) == month)
                .GroupBy(x => SqlFunctions.DatePart("day", x.DateOfContribution))
                .ToDictionary(v => v.Key, v => v.Sum(c => c.AmountContributed));

            return dailyFunding;
        }

        public Dictionary<string, int> GetFundersPerProvince(int campaignId)
        {
            var funders = _dataSession.UnitOfWork.Context.Set<CampaignSponsor>()
                .Where(x => x.CampaignId == campaignId)
                .DistinctBy(x => x.SponsorId)
                .ToList();

            var dictionary = new Dictionary<string, int>
            {
                {"Eastern Cape", 0},
                {"Free State", 0},
                {"Gauteng", 0},
                {"Kwa-Zulu Natal", 0},
                {"Limpopo", 0},
                {"Mpumalanga", 0},
                {"Northern Cape", 0},
                {"North West", 0},
                {"Western Cape", 0}
            };

            foreach (var funder in funders)
            {
                var address = _dataSession.UnitOfWork.Context.Set<UserAddress>()
                    .FirstOrDefault(x => x.BursifyUserId == funder.SponsorId);

                if (address == null || !dictionary.ContainsKey(address.Province)) continue;
                string province = address.Province;
                dictionary[province] += 1;
            }

            return dictionary;
        }
        
    }
}