using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Api.Users
{
    public class UserApi
    {
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;
        protected readonly Repository<BursifyUser> userRepository;
        protected readonly CampaignRepository campaignRepository;
        protected readonly CampaignSponsorRepository campaignSponsorRepository;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, Repository<BursifyUser> userRepository, CampaignRepository campaignRepository, CampaignSponsorRepository campaignSponsorRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.campaignRepository = campaignRepository;
            this.campaignSponsorRepository = campaignSponsorRepository;
        }

        public List<BursifyUser> ShowAllUsers()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadAll();
            }
        }

        public BursifyUser GetUserInfo(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadById(Id);
            }
        }

        public void UpdateUser(BursifyUser user)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Save(user);
                uow.Commit();
            }
        }

        public void UpdateUser(int Id, string accountStatus, ICollection<UserAddress> address, string bio, string cellno, string email, string name, string picPath, string telno)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(Id);
                user.AccountStatus = accountStatus;
                user.Addresses = address;
                user.Biography = bio;
                user.CellphoneNumber = cellno;
                user.Email = email;
                user.Name = name;
                user.ProfilePicturePath = picPath;
                user.TelephoneNumber = telno;
                UpdateUser(user);
            }
        }

        public void DeleteUser(BursifyUser user)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Delete(user);
                uow.Commit();
            }
        }

        public void DeleteUserById(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Delete(Id);
                uow.Commit();
            }
        }

        public List<Campaign> GetCampaigns()
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignRepository.GetAllCampaigns();
            }
        }

        public Campaign EndorseCampaign(int userId, int campaignId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(userId);
                var campaign = campaignRepository.EndorseCampaign(user, campaignId);

                uow.Commit();
                return campaign;
            }
        }

        public bool IsEndorsed(int userId, int campaignId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(userId);
                return campaignRepository.IsEndorsed(user, campaignId);
            }

        }

        public int GetNumberOfCampaignSupporters(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return campaignSponsorRepository.GetNumberOfSupportersOfCampaign(Id);
            }
        }
    }
}