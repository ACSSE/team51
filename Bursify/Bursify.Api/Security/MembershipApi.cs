using System;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;

namespace Bursify.Api.Security
{
    public class MembershipApi
    {
        private readonly BursifyUserRepository _userRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICryptoService _cryptoService;

        public MembershipApi(BursifyUserRepository userRepository, ICryptoService cryptoService,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this._userRepository = userRepository;
            this._cryptoService = cryptoService;
            this._unitOfWorkFactory = unitOfWorkFactory;
        }


        public bool Login(string userName, string password)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var bursifyUser = _userRepository.GetUserByEmail(userName);
                if (bursifyUser == null)
                {
                    return false;
                }

                if (IsPasswordValid(bursifyUser, password))
                {
                    return true;
                }
            }

            return false;
        }

        public BursifyUser RegisterUser(string userEmail, string password, string userType)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = _userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    return null;
                }

                var salt = _cryptoService.CreateSalt();

                

                user = new BursifyUser
                {
                    Email = userEmail,
                    PasswordHash = _cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    UserType = userType,
                    AccountStatus = "Active",
                    RegistrationDate = DateTime.UtcNow,
                    ProfilePicturePath = "def"
                };

                _userRepository.Save(user);
                uow.Commit();
            }
            return user;
        }

        public bool IsPasswordValid(BursifyUser user, string password)
        {
            return _cryptoService.HashPassword(password, user.PasswordSalt) == user.PasswordHash;
        }

        public BursifyUser GetUserByEmail(string email)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                user = _userRepository.GetUserByEmail(email);
            }

            return user;
        }

        public BursifyUser GetUserById(int id)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                user = _userRepository.GetUserById(id);
            }

            return user;
        }

        public void UpdateUser(BursifyUser user)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _userRepository.Save(user);
                uow.Commit();
            }

        }
    }
}