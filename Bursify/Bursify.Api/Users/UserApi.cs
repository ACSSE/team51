using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;
using System;

namespace Bursify.Api.Users
{
    public class UserApi
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly Repository<BursifyUser> _userRepository;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, Repository<BursifyUser> userRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
        }

        //Registration of a new user
        public void CreateUser(string name, string email, string passwordhash, string passwordSalt, string userType)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = new BursifyUser();
                user.Name = name;
                user.Email = email;
                user.PasswordHash = passwordhash;
                user.PasswordSalt = passwordSalt;
                user.AccountStatus = "Active";

                user.UserType = userType;
                user.RegistrationDate = DateTime.Today;
                user.Biography = "";
                _userRepository.Save(user);

                //delete


                //send email

                uow.Commit();
            }
        }

        public BursifyUser GetUserByEmail(string email)
        {
            var user = _userRepository.FindSingle(x => x.Email.Contains(email));

            return user;
        }

        public string ShowAllUsers()
        {
            return "works";
        }
    }
}