using Bursify.Data.Extensions;
using Bursify.Data.Repositories;
using Bursify.Data.UoW;
using Bursify.Entities;
using Bursify.Entities.UserEntities;
using Bursify.Services.Abstract;
using Bursify.Services.Utilitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Bursify.Services
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IEntityBaseRepository<BursifyUser> _BursifyUserRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public MembershipService(IEntityBaseRepository<BursifyUser> BursifyUserRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _BursifyUserRepository = BursifyUserRepository;
        
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        public MembershipContext ValidateUser(string email, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _BursifyUserRepository.GetAUserByEmail(email);
            if (user != null && isUserValid(user, password))
            {
             
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Name);
                membershipCtx.Principal = new GenericPrincipal(identity, new String[] {
                ""});
            }
            

            return membershipCtx;
        }

  

        public BursifyUser GetUser(int userId)
        {
            return _BursifyUserRepository.GetSingle(userId);
        }

        public BursifyUser CreateUser(string username, string email, string password, string type)
        {
            var existingUser = _BursifyUserRepository.GetAUserByEmail(email);

            if (existingUser != null)
            {
                throw new Exception("Email is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new BursifyUser()
            {
                Name = username,
                PasswordSalt = passwordSalt,
                Email = email,
                UserType = type,
                AccountStatus = "Active",
                PasswordHash = _encryptionService.EncryptPassword(password, passwordSalt),
                RegistrationDate = DateTime.Now
            };

            _BursifyUserRepository.Add(user);

            _unitOfWork.Commit();

            return user;
        }

    
        private bool isPasswordValid(BursifyUser user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.PasswordSalt), user.PasswordHash);
        }

        private bool isUserValid(BursifyUser user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return true;
            }

            return false;
        }
    }
}
