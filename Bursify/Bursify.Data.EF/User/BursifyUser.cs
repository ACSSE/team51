using Bursify.Data.EF;
using Bursify.Data.Enums;
using Bursify.Data.SponsorUser;
using Bursify.Data.StudentUser;
using System;
using System.Collections.Generic;

namespace Bursify.Data.User
{
    public class BursifyUser : IEntity
    {
        public BursifyUser()
        {
            Contacts = new List<Contact>();
            Sponsors = new List<Sponsor>();
            Students = new List<Student>();
        }

        public int BursifyUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool AccountStatus { get; set; }
        public string UserType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Biography { get; set; }

        public int Id
        {
            get { return BursifyUserId; }
        }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}