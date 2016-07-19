using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.User;

namespace Bursify.Api.Students
{
    public class StudentApi
    {
        #region Variables

        private readonly Repository<Account> _accountRepository;
        private readonly Repository<Campaign> _campaignRepository;
        private readonly Repository<Sponsorship> _sponsorshipRepository;
        private readonly SponsorRepository _sponsorRepository;
        private readonly Repository<Student> _studentRepository;
        private readonly Repository<Institution> _institutionRepository;

        #endregion

        public Account GetAccount(int id)
        {
            var account = _accountRepository.LoadById(id);

            return account;
        }

        public void AddCampaign(Campaign campaign)
        {
            _campaignRepository.Save(campaign);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public Campaign GetSIngleCampaign(int id)
        {
            var campaign = _campaignRepository.LoadById(id);

            return campaign;
        }

        public List<Campaign> GetAllCampaigns()
        {
            var campaigns = _campaignRepository.LoadAll();

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
            var sponsors = _sponsorRepository.LoadAll();

            return sponsors;
        }

        public List<Sponsor> GetTopTenSponsors()
        {
            return _sponsorRepository.GetTop10Sponsors();
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