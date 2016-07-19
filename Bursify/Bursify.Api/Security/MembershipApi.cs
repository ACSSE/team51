using System;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.User;
using Bursify.Services;

namespace Bursify.Api.Security
{
    public class MembershipApi
    {
        private readonly Repository<BursifyUser> userRepository;
        private readonly ICryptoService cryptoService ;

        public MembershipApi(Repository<BursifyUser> userRepository, ICryptoService cryptoService)
        {
            this.userRepository = userRepository;
            this.cryptoService = cryptoService;
        }

        public bool Login(string userName, string password)
        {
            var bursifyUser = this.userRepository.FindSingle(x => x.Email == userName);
            if (bursifyUser == null)
            {
                return false;
            }

            if (bursifyUser.PasswordHash == cryptoService.HashPassword(password, bursifyUser.PasswordSalt))
            {
                return true;
            }

            return false;
        }

        public BursifyUser RegisterUser(string username, string userEmail, string password, string userType)
        {
            var salt = cryptoService.CreateSalt();

            BursifyUser user = new BursifyUser();

            user.Email = userEmail;
            user.Name = username;
            user.PasswordHash = cryptoService.HashPassword(password, salt);
            user.PasswordSalt = salt;
            user.UserType = userType;
            user.RegistrationDate = DateTime.UtcNow;

            userRepository.Save(user);

            return user;
        }
    }
}