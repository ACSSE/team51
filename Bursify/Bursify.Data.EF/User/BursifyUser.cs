using System;
using System.Collections.Generic;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;

namespace Bursify.Data.EF.User
{
    public class BursifyUser : IEntity
    {
        public BursifyUser()
        {
            //Student = new Student();
            Addresses = new List<UserAddress>();
            //Sponsors = new List<Sponsor>();
        }

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

        public int Id
        {
            get { return BursifyUserId; }
        }

        public virtual ICollection<UserAddress> Addresses { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        public virtual Student Student { get; set; }
    }
}