using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;

namespace Bursify.Api.Students
{
    public class StudentApi
    {
        #region Variables

        private readonly AccountRepository _accountRepository = new AccountRepository(new DataSession());
        private readonly CampaignRepository _campaignRepository = new CampaignRepository(new DataSession());
        private readonly SponsorshipRepository _sponsorshipRepository = new SponsorshipRepository(new DataSession());
        private readonly SponsorRepository _sponsorRepository = new SponsorRepository(new DataSession());
        //private readonly StudentRepository _studentRepository = new StudentRepository(new DataSession());
        private readonly InstitutionRepository _institutionRepository = new InstitutionRepository(new DataSession());

        #endregion

        //done
        public Account GetAccount(int id)
        {
            return _accountRepository.GetAccount(id);
        }

        //done
        public void SaveCampaign(Campaign campaign)
        {
            _campaignRepository.Save(campaign);
        }

        //done
        public Campaign GetSIngleCampaign(int id)
        {
            return _campaignRepository.GetCampaign(id);
        }

        //done
        public List<Campaign> GetAllCampaigns()
        {
            var campaigns = _campaignRepository.LoadAll();

            return campaigns;
        }

        //for later
        public void ShareCampaign(int id)
        {
            throw new NotImplementedException();
        }

        //for later
        public void EndorseCampaign(int id)
        {
            throw new NotImplementedException();
        }

        //done
        public List<Campaign> SearchCampaigns(string criteria)
        {
            return _campaignRepository.FindCampaigns(criteria.ToUpper()).ToList();
        }

        //done
        public List<Sponsor> GetAllSponsors()
        {
            var sponsors = _sponsorRepository.LoadAll();

            return sponsors;
        }

        //done
        public List<Sponsor> GetTopTenSponsors()
        {
            return _sponsorRepository.GetTop10Sponsors();
        }

        //done
        public Sponsor GetSponsor(int id)
        {
            return _sponsorRepository.GetSponsor(id);
        }

        //done
        public List<Sponsorship> GetAllSponsorships()
        {
            return _sponsorshipRepository.LoadAll();
        }

        //done
        public Sponsorship GetSponsorship(int id, int userId)
        {
            return _sponsorshipRepository.GetSponsorship(id, userId);
        }

        //done
        public List<Sponsorship> SearchSponsorships(string criteria)
        {
            return _sponsorshipRepository.FindSponsorships(criteria.ToUpper()).ToList();
        }

        //for later
        public void RateSponsorship()
        {
            throw new NotImplementedException();
        }

        //for later
        public void ShareSponsorship()
        {
            throw new NotImplementedException();
        }

        //done
        public Institution GetInstitution(int id)
        {
            return _institutionRepository.GetInstitution(id);
        }

        //done
        public void SaveInstitution(Institution institution)
        {
            _institutionRepository.Save(institution);
        }

    }
}