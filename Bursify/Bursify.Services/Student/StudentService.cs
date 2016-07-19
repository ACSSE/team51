using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.Repositories;
using Bursify.Entities.StudentEntities;
using Bursify.Entities.CampaignEntities;
using Bursify.Entities.SponsorEntities;
using Bursify.Entities.UserEntities;
using Bursify.Services.Abstract;

namespace Bursify.Services.Student
{
    public class StudentService : IStudentRepository
    {
        #region Variables

        private readonly EntityBaseRepository<Account> _accountRepository;
        private readonly EntityBaseRepository<Campaign> _campaignRepository;
        private readonly EntityBaseRepository<Sponsorship> _sponsorshipRepository;
        private readonly EntityBaseRepository<Sponsor> _sponsoRepository;
        private readonly EntityBaseRepository<Entities.StudentEntities.Student> _studentRepository;
        private readonly EntityBaseRepository<Institution> _institutionRepository;

        #endregion

        public Account GetAccount(int id)
        {
            var account = _accountRepository.GetSingle(id);

            return account;
        }

        public void AddCampaign(Campaign campaign)
        {
            _campaignRepository.Add(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public Campaign GetSIngleCampaign(int id)
        {
            var campaign = _campaignRepository.GetSingle(id);

            return campaign;
        }

        public List<Campaign> GetAllCampaigns()
        {
            var campaigns = _campaignRepository.GetAll().ToList();

            return campaigns;
        }

        public void ShareCampaign(int id)
        {
            throw new NotImplementedException();
        }

        public void EndorseCampaign(int id)
        {
            throw new NotImplementedException();
        }

        public List<Campaign> FindCampaigns(/*questions*/)
        {
            throw new NotImplementedException();
        }

        public List<Sponsor> GetAllSponsors()
        {
            var sponsors = _sponsoRepository.GetAll().ToList();

            return sponsors;
        }

        public List<Sponsor> GetTopTenSponsors()
        {
            var topSponsors = ((from sponsor in _sponsoRepository.GetAll()
                orderby sponsor.BursifyRank
                select sponsor).Distinct().Take(10)).ToList();

            return topSponsors;
        }

        public Sponsor GetSponsor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sponsorship> GetAllSponsorships()
        {
            throw new NotImplementedException();
        }

        public Sponsorship GetSponsorship(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sponsorship> FindSponsorships()
        {
            throw new NotImplementedException();
        }

        public void RateSponsorship()
        {
            throw new NotImplementedException();
        }

        public void ShareSponsorship()
        {
            throw new NotImplementedException();
        }

        public Institution GetInstitution(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInstitution(Institution institution)
        {
            throw new NotImplementedException();
        }

        public void AddInstitution(Institution institution)
        {
            throw new NotImplementedException();
        }
    }
}
