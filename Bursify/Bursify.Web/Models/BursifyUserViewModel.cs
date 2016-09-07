using System;
using Bursify.Data.EF.Entities.User;
using System.Linq;
using System.Collections.Generic;
using Bursify.Api.Students;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Web.Models
{
    public class BursifyUserViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string AccountStatus { get; set; }
        public string UserType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Biography { get; set; }
        public string CellphoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string ProfilePicturePath { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public Student Student { get; set; }

        public string Name { get; set; }

        public BursifyUser MapSingleBursifyUser(BursifyUser user)
        {
            return new BursifyUser()
            {
                ID = user.ID,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                AccountStatus = user.AccountStatus,
                UserType = user.UserType,
                RegistrationDate = user.RegistrationDate,
                Biography = user.Biography,
                CellphoneNumber = user.CellphoneNumber,
                TelephoneNumber = user.TelephoneNumber,
                ProfilePicturePath = user.ProfilePicturePath,
                Addresses = UserAddressViewModel.ReverseMapMultipleAddresses(UserAddressViewModel.MapMultipleAddresses((List<UserAddress>)user.Addresses)),
                Student = (new StudentViewModel()).ReverseMap(user.Student)
            };
        }

        public BursifyUserViewModel ReverseMapUser(BursifyUser user)
        {
            ID = user.ID;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            PasswordSalt = user.PasswordSalt;
            AccountStatus = user.AccountStatus;
            UserType = user.UserType;
            RegistrationDate = user.RegistrationDate;
            Biography = user.Biography;
            CellphoneNumber = user.CellphoneNumber;
            TelephoneNumber = user.TelephoneNumber;
            ProfilePicturePath = user.ProfilePicturePath;

            return this;
        }

        public List<BursifyUser> MapMultipleBursifyUsers(List<BursifyUser> bursifyUsers)
        {
            return (from user in bursifyUsers select MapSingleBursifyUser(user)).ToList();
        }
    }
}