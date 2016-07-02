using Bursify.Data.CampaignUser;
using Bursify.Data.EF;
using Bursify.Data.EF.User;
using Bursify.Data.User;
using System.Collections.Generic;

namespace Bursify.Data.StudentUser
{
    public class Student : IEntity
    {
        public Student()
        {
            Campaigns = new List<Campaign>();
            Institutions = new List<Institution>();
        }

        public int StudentId { get; set; }
        public string EducationLevel { get; set; }
        public int AverageMark { get; set; }
        public string ProfilePicturePath { get; set; }
        public int BursifyUserId { get; set; }
        public virtual BursifyUser StudentUser { get; set; }

        public int Id
        {
            get { return StudentId; }
        }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Institution> Institutions { get; set; }
    }
}