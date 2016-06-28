using Bursify.Data.EF;
using Bursify.Data.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bursify.Data.SponsorUser
{
    public class Requirement 
    {
        public int BursifyUserId { get; set; }
        public string StudyField { get; set; }
        public double AverageMark { get; set; }
        public string Province { get; set; }
        [Key, ForeignKey("Subjects")]
        public int SubjectId { get; set; }

        public virtual Subject Subjects { get; set; }
    }
}