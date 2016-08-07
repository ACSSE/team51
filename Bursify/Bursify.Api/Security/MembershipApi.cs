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
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly ICryptoService cryptoService;

        public MembershipApi(BursifyUserRepository userRepository, ICryptoService cryptoService,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
            this.unitOfWorkFactory = unitOfWorkFactory;
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

    }
}