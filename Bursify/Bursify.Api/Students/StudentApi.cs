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

        private readonly AccountRepository _accountRepository;
        private readonly CampaignRepository _campaignRepository;
        private readonly SponsorshipRepository _sponsorshipRepository;
        private readonly SponsorRepository _sponsorRepository;
        //private readonly StudentRepository _studentRepository;
        private readonly InstitutionRepository _institutionRepository;

        #endregion

        #region Campaign
        //not done
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
        public Campaign GetSingleCampaign(int campaignId)   //done
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.GetCampaign(campaignId);
            }
        }

        /// <summary>
        /// Get a single campaign
        /// </summary>
        /// <param name="campaignId"> Id of campaign to retrieve </param>
        /// <param name="userId"> Id of student </param>
        /// <returns></returns>
        public Campaign GetSingleCampaign(int campaignId, int userId)   //done
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.GetCampaign(campaignId, userId);
            }
        }

        /// <summary>
        /// Gets all active the campaigns
        /// </summary>
        /// <returns> All active campaigns</returns>
        public List<Campaign> GetAllCampaigns() //done
        {
            List<Campaign> campaigns = null;
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                campaigns = _campaignRepository.GetAllCampaigns();
            }

            return campaigns;
        }

        /// <summary>
        /// Gets all campaigns belonging to a specific student
        /// </summary>
        /// <param name="userId"> unique id for the student </param>
        /// <returns> List of campaigns created by a student </returns>
        public List<Campaign> GetAllCampaigns(int userId)   //done
        {
            List<Campaign> userCampaigns = null;
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userCampaigns = _campaignRepository.GetUserCampaigns(userId).ToList();
            }
            return userCampaigns;
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
        public List<Campaign> SearchCampaigns(string criteria)  //done
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _campaignRepository.FindCampaigns(criteria.ToUpper()).ToList();
            }
        }

        #endregion

        #region Sponsor
        //not done
        public List<Sponsor> GetAllSponsors()
        {
            var sponsors = _sponsorRepository.LoadAll().ToList();

            return sponsors;
        }

        //not done
        public List<Sponsor> GetTopTenSponsors()
        {
            return _sponsorRepository.GetTop10Sponsors();
        }

        //not done
        public Sponsor GetSponsor(int id)
        {
            return _sponsorRepository.GetSponsor(id);
        }

        #endregion

        #region Sponsorship
        //done
        public void SaveSponsorship(Sponsorship sponsorship)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                _sponsorshipRepository.Save(sponsorship);

                uow.Commit();
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships();
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships(userId);
            }
        }

        //done
        public List<Sponsorship> GetAllSponsorships(string type)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetAllSponsorships(type);
            }
        }

        //done
        public Sponsorship GetSponsorship(int id, int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetSponsorship(id, userId);
            }
        }

        //done
        public Sponsorship GetSponsorship(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.GetSponsorship(id);
            }
        }

        //done
        public List<Sponsorship> SearchSponsorships(string criteria)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _sponsorshipRepository.FindSponsorships(criteria.ToUpper()).ToList();
            }
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

        #endregion

        #region School
        //done
        public Institution GetInstitution(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return _institutionRepository.GetInstitution(userId);
            }
        }

        //done
        public void SaveInstitution(Institution institution)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                _institutionRepository.Save(institution);
                uow.Commit();
            }
        }

        #endregion
    }
}