using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Data.EF.Entities.User
{
    public class BursifyUser : IEntity
    {
        public BursifyUser()
        {
            //Student = new Student();
            Addresses = new List<UserAddress>();
            //Sponsors = new List<Sponsor>();
        }

        public int ID { get; set; }
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

        public virtual ICollection<UserAddress> Addresses { get; set; }
        public virtual ICollection<CampaignReport> CampaignReports { get; set; }
        public virtual ICollection<Campaign> Upvotes { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        public virtual Student Student { get; set; }
    }
}