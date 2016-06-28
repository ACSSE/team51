using Bursify.Data.CampaignUser;
using Bursify.Data.EF;
using Bursify.Data.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.StudentUser
{
    public class Student
    {
        public int StudentId { get; set; }
        public string IdNumber { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string ProfilePicPath { get; set; }
        public double MarkAverage { get; set; }
        [Key, ForeignKey("Campaigns")]
        public int CampaignId { get; set; }
        [Key, ForeignKey("Subjects")]
        public int SubjectId { get; set; }
        
        public virtual Campaign Campaigns { get; set; }
        public virtual Subject  Subjects { get; set; }
    }
}