using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Data.User;
using System;

namespace Bursify.Api.Users
{
    public class UserApi
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly Repository<BursifyUser> _userRepository;
        private readonly Repository<BursifyUser> _contact;

        public UserApi(IUnitOfWorkFactory unitOfWorkFactory, Repository<BursifyUser> userRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
          
        }

        public void CreateUser(string name)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var user = new BursifyUser();
                user.Name = name;
                user.Email = "brandon@gmail.com";
                user.PasswordHash = "password123";
                user.PasswordSalt = "passwordSalt";
                user.AccountStatus = true;

                user.UserType = "Admin";
                user.RegistrationDate = new DateTime(2016, 6, 10);
                user.Biography = "Bio stuff";
                _userRepository.Save(user);
               
                //delete


                //send email

                uow.Commit();
            }
        }
    }
}