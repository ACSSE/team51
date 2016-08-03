using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Services;

namespace Bursify.Api.Security
{
    public class MembershipApi
    {
        private readonly BursifyUserRepository userRepository;
        private readonly CampaignRepository campaignRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly ICryptoService cryptoService;

        public MembershipApi(BursifyUserRepository userRepository, ICryptoService cryptoService,
            IUnitOfWorkFactory unitOfWorkFactory, CampaignRepository campaignRepository)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.campaignRepository = campaignRepository;
        }


        public bool Login(string userName, string password)
        {
            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var bursifyUser = userRepository.GetUserByEmail(userName);
                if (bursifyUser == null)
                {
                    return false;
                }

                if (isPasswordValid(bursifyUser, password))
                {
                    return true;
                }
            }

            return false;
        }

        public BursifyUser RegisterUser(string username, string userEmail, string password, string userType)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    throw new Exception("Email is already in use");
                }

                var salt = cryptoService.CreateSalt();

                user = new BursifyUser
                {
                    Email = userEmail,
                    Name = username,
                    PasswordHash = cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    UserType = userType,
                    AccountStatus = "InActive",
                    RegistrationDate = DateTime.UtcNow
                };

                userRepository.Save(user);
                uow.Commit();
            }
            return user;
        }


        private bool isPasswordValid(BursifyUser user, string password)
        {
            return cryptoService.HashPassword(password, user.PasswordSalt) == user.PasswordHash;
        }

        public BursifyUser GetUserByEmail(string email)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            {
                user = userRepository.GetUserByEmail(email);
            }

            return user;
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
                var campaign = campaignRepository.IsEndorsed(user, campaignId);

                if (campaign == null)
                {
                    return false;
                }
            }
            return true;
        }



    }
}