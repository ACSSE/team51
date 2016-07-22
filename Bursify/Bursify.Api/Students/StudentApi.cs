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
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public StudentApi(CampaignRepository campaignRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _campaignRepository = campaignRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        #region Variables

        private readonly AccountRepository _accountRepository = new AccountRepository(new DataSession());
        private readonly CampaignRepository _campaignRepository;// = new CampaignRepository(new DataSession());
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
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                _campaignRepository.Save(campaign);
                uow.Commit();
            }
        }

        /// <summary>
        /// Get a single camapign
        /// </summary>
        /// <param name="campaignId"> Id for the campaign </param>
        /// <returns> A single campaign </returns>
        public Campaign GetSingleCampaign(int campaignId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.GetCampaign(campaignId);
            }
        }

        //done
        /// <summary>
        /// Get a single campaign
        /// </summary>
        /// <param name="campaignId"> Id of campaign to retrieve </param>
        /// <param name="userId"> Id of student </param>
        /// <returns></returns>
        public Campaign GetSIngleCampaign(int campaignId, int userId)
        {
            return _campaignRepository.GetCampaign(campaignId, userId);
        }

        //done
        /// <summary>
        /// Gets all active the campaigns
        /// </summary>
        /// <returns> All active campaigns</returns>
        public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> campaigns = null;
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                campaigns = _campaignRepository.GetAllCampaigns();
            }

            return campaigns;
        }

        //done
        /// <summary>
        /// Gets all campaigns belonging to a specific student
        /// </summary>
        /// <param name="userId"> unique id for the student </param>
        /// <returns> List of campaigns created by a student </returns>
        public List<Campaign> GetAllCampaigns(int userId)
        {
            return _campaignRepository.GetUserCampaigns(userId).ToList();
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
            var sponsors = _sponsorRepository.LoadAll().ToList();

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
            return _sponsorshipRepository.LoadAll().ToList();
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