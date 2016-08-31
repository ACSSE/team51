using System;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Api.Users
{
    public class UserApi
    {
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;
        protected readonly BursifyUserRepository userRepository;
        protected readonly Repository<UserAddress> userAddressRepository;
        protected readonly CampaignRepository campaignRepository;
        protected readonly CampaignSponsorRepository campaignSponsorRepository;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, BursifyUserRepository userRepository, Repository<UserAddress> userAddressRepository, CampaignRepository campaignRepository, CampaignSponsorRepository campaignSponsorRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.userAddressRepository = userAddressRepository;
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

        public BursifyUser GetCompleteUser(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<BursifyUser>()
                    .Where(x => x.ID == userId)
                    .Include(x => x.Addresses)
                    .Include(x => x.Student)
                    .FirstOrDefault();

                return user;
            }
        }

        public bool ValidateEmail(string email)
        {
            var e = userRepository.GetUserByEmail(email);

            if (e == null)
            {
                return true;
            }

            return false;
        }

        public void UpdateUser(BursifyUser user)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userRepository.Save(user);
                uow.Commit();
            }
        }

        public void UpdateUser(int Id, string accountStatus, ICollection<UserAddress> address, string bio, string cellno, string email, string picPath, string telno)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = userRepository.LoadById(Id);
                user.AccountStatus = accountStatus;
                user.Addresses = address;
                user.Biography = bio;
                user.CellphoneNumber = cellno;
                user.Email = email;
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

        public List<UserAddress> GetAddressofUser(int Id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return userRepository.LoadById(Id).Addresses.ToList();
            }
        }

        public void SaveAddress(UserAddress address)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                userAddressRepository.Save(address);
                uow.Commit();
            }
        }

        public UserAddress GetAddress(int userId, string type)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var address =
                    userAddressRepository.FindSingle(
                                x => x.BursifyUserId == userId
                             && x.AddressType.Equals(type, StringComparison.OrdinalIgnoreCase));

                return address;
            }
        }
    }
}