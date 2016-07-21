using System;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;
using Bursify.Services;

namespace Bursify.Api.Security
{
    public class MembershipApi
    {
        private readonly BursifyUserRepository userRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly ICryptoService cryptoService ;

        public MembershipApi(BursifyUserRepository userRepository, ICryptoService cryptoService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public bool ValidateUser(string email, string password)
        {
            var bursifyUser = userRepository.GetUserByEmail(email);
            if (bursifyUser == null)
            {
                return false;
            }

            if (isPasswordValid(bursifyUser, password))
            {
                return true;
            }

            return false;
        }

        public BursifyUser RegisterUser(string username, string userEmail, string password, string userType)
        {

            var existingUser = userRepository.GetUserByEmail(userEmail);

            if (existingUser != null)
            {
                throw new Exception("Email is already in use");
            }

            BursifyUser user = null;

            using (IUnitOfWork uow = unitOfWorkFactory.CreateUnitOfWork())
            { 
                var salt = cryptoService.CreateSalt();

                user = new BursifyUser
                {
                    Email = userEmail,
                    Name = username,
                    PasswordHash = cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    UserType = userType,
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
    }

}