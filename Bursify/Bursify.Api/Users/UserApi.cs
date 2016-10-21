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
        protected readonly NotificationRepository notificationRepository;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, BursifyUserRepository userRepository, Repository<UserAddress> userAddressRepository, CampaignRepository campaignRepository, CampaignSponsorRepository campaignSponsorRepository, NotificationRepository notificationRepository)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.userRepository = userRepository;
            this.userAddressRepository = userAddressRepository;
            this.campaignRepository = campaignRepository;
            this.campaignSponsorRepository = campaignSponsorRepository;
            this.notificationRepository = notificationRepository;
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

        public BursifyUser GetCompletStudentUser(int userId)
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

        public BursifyUser GetCompletStudentUser(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<BursifyUser>()
                    .Where(x => x.Email.Equals(email))
                    .Include(x => x.Addresses)
                    .Include(x => x.Student)
                    .FirstOrDefault();

                return user;
            }
        }

        public string GetUserType(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.Context.Set<BursifyUser>()
                    .Where(x => x.ID == userId)
                    .Select(x => x.UserType)
                    .FirstOrDefault();
            }
        }

        public string GetUserType(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return uow.Context.Set<BursifyUser>()
                    .Where(x => x.Email.Equals(email))
                    .Select(x => x.UserType)
                    .FirstOrDefault();
            }
        }

        public BursifyUser GetCompletSponsorUser(int userId)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<BursifyUser>()
                    .Where(x => x.ID == userId)
                    .Include(x => x.Addresses)
                    .Include(x => x.Sponsor)
                    .FirstOrDefault();

                return user;
            }
        }

        public BursifyUser GetCompletSponsorUser(string email)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = uow.Context.Set<BursifyUser>()
                    .Where(x => x.Email.Equals(email))
                    .Include(x => x.Addresses)
                    .Include(x => x.Sponsor)
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

        public void CreateNotification(Notification n)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                notificationRepository.Save(n);
                uow.Commit();
            }
        }

        public int GetNumberOfUnreadMessages(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return notificationRepository.getNumberOfUnreadMessages(id);
            }
        }

        public List<Notification> GetNotifications(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return notificationRepository.GetNotifications(id);
            }
        }

        public Notification GetSingleNotification(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                return notificationRepository.GetSingleNotification(id);
            }
        }

        public void MarkAllRead(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                notificationRepository.MarkAllRead(id);
                uow.Commit();
            }
        }

        public void MarkSingleRead(int id)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                notificationRepository.MarkSingleRead(id);
                uow.Commit();
            }
        }
    }
}