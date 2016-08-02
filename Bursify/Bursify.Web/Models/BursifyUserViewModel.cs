using System;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class BursifyUserViewModel
    {
        public int BursifyUserId { get; set; }
        public string Name { get; set; }
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

        public BursifyUserViewModel(BursifyUser user)
        {
            BursifyUserId = user.ID;
            Name = user.Name;
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
        }
    }
}