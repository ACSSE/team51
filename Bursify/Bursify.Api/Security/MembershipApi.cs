﻿using System;
using System.Collections.Generic;
using Bursify.Api.Students;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;
using Bursify.Services;

namespace Bursify.Api.Security
{
    public class MembershipApi
    {
        private readonly BursifyUserRepository _userRepository;
        private readonly UserAddressRepository _addressRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICryptoService _cryptoService;

        public MembershipApi(BursifyUserRepository userRepository, UserAddressRepository addressRepository, IUnitOfWorkFactory unitOfWorkFactory, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
            _cryptoService = cryptoService;
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

        public BursifyUser RegisterUser(string username, string userEmail, string password, string userType)
        {
            BursifyUser user = null;

            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var existingUser = _userRepository.GetUserByEmail(userEmail);
                if (existingUser != null)
                {
                    return null;
                    //throw new Exception("Email is already in use");
                }

                var salt = _cryptoService.CreateSalt();

                user = new BursifyUser
                {
                    Email = userEmail,
                    Name = username,
                    PasswordHash = _cryptoService.HashPassword(password, salt),
                    PasswordSalt = salt,
                    UserType = userType,
                    AccountStatus = "Active",
                    RegistrationDate = DateTime.UtcNow
                };

                _userRepository.Save(user);
               
                uow.Commit();

            }
            return user;
        }

        private bool IsPasswordValid(BursifyUser user, string password)
        {
            return _cryptoService.HashPassword(password, user.PasswordSalt) == user.PasswordHash;
        }

        public BursifyUser GetUserByEmail(string email)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _userRepository.GetUserByEmail(email);
            }
        }

        public void UpdateUser(BursifyUser user)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _userRepository.Save(user);

                uow.Commit();
            }
        }

        public void SaveUserAddress(UserAddress address)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                _addressRepository.Save(address);

                uow.Commit();
            }
        }

        public UserAddress GetUserAddress(int userId, string addressType)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _addressRepository.GetUserAddress(userId, addressType);
            }
        }

        public List<UserAddress> GetUserAddresses(int userId)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.CreateUnitOfWork())
            {
                return _addressRepository.GetAllUserAddress(userId);
            }
        }
    }
}